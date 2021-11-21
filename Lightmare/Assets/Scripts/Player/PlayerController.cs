using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] float sensitivity;
    [SerializeField] float normalMaxSpeed;
    [SerializeField] float airMaxSpeed;
    [SerializeField] float clampOffset;
    [SerializeField] float normalAcceleration;//the acceleration in the z direction
    [SerializeField] float boostedAcceleration;
    [SerializeField] float stunTime;
    [SerializeField] float horizontalDampener;

    [Header("Jump")]
    [SerializeField] float jumpForce;

    float targetOffset;
    Vector3 mouseMovement;
    Vector3 lastMousePos;
    Vector3 startPosition;
    Rigidbody rb;
    float finishDrag = 2;
    float normalDrag;
    float maxSpeed;
    float acceleration;
    SphereCollider collider;

    bool active;
    bool isStunned;

    bool isTouchingGround;

    bool wasClicked;

    [HideInInspector]
    public bool IsTouchingGroundSetter
    {
        set { isTouchingGround = value; }
    }

    public float getCurrentSpeed() { return rb.velocity.z; }


    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        StartGame();//remove when events are properly implemented
        normalDrag = rb.drag;
        collider = GetComponent<SphereCollider>();
        maxSpeed = normalMaxSpeed;
        acceleration = normalAcceleration;
        #region events
        GameManager.Instance.failGame += ResetPosition;
        GameManager.Instance.finishGame += Finish;
        GameManager.Instance.restart += ResetPosition;
        GameManager.Instance.stunPlayer += GetStunned;
        GameManager.Instance.startBoost += StartBoost;
        GameManager.Instance.stopBoost += StopBoost;
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (!isTouchingGround)//changes the steering speed based on wether the player is in the air
            {
                maxSpeed = airMaxSpeed;
            }
            else { maxSpeed = normalMaxSpeed; }


            rb.AddForce(new Vector3(0f, 0f, acceleration * 100f * rb.mass * Time.deltaTime));
            if (!isStunned)//While clicked
            {
                if (Input.GetMouseButton(0))//while clicked
                {
                    if (!wasClicked)// On click start
                    {
                        lastMousePos = Input.mousePosition;
                        targetOffset = transform.position.x;
                        target.position = transform.position;
                        wasClicked = true;
                    }
                    else
                    {
                        mouseMovement = Input.mousePosition - lastMousePos;
                        targetOffset += mouseMovement.x * sensitivity;
                        targetOffset = Mathf.Clamp(targetOffset, -clampOffset, clampOffset);//Clamps the position of the offset
                        target.position = new Vector3(targetOffset, transform.position.y, transform.position.z);
                        rb.velocity = new Vector3(Mathf.Clamp((target.position.x - transform.position.x) * 10f, -maxSpeed, maxSpeed),
                        rb.velocity.y, rb.velocity.z);//Moves the character
                    }
                }
                else
                {
                    if (wasClicked)
                    {
                        TryToJump();
                        wasClicked = false;
                    }
                    targetOffset = transform.position.x;
                    target.position = transform.position;
                    rb.velocity = new Vector3(rb.velocity.x * (1f - horizontalDampener * Time.deltaTime), rb.velocity.y, rb.velocity.z);//extra dampener when not controlling the player
                }
            }
            else
            {

                targetOffset = transform.position.x;
                target.position = transform.position;
            }


            lastMousePos = Input.mousePosition;
            if (transform.position.y < 0f)
            {
                GameManager.Instance.Fail();
            }
        }
    }

    void StartGame()
    {
        active = true;
    }

    /// <summary>
    /// Resets the player to the start of the level
    /// </summary>
    void ResetPosition()
    {
        transform.position = startPosition;
        rb.velocity = Vector3.zero;
        rb.drag = normalDrag;
        active = true;
    }

    void Finish()
    {
        active = false;
        rb.drag = finishDrag;
    }

    void GetStunned()
    {
        StartCoroutine(StunPlayer(stunTime));
    }

    /// <summary>
    /// Changes the state of the player to stunned and back
    /// </summary>
    /// <param name="time">The amount of time the player is stunned</param>
    /// <returns></returns>
    public IEnumerator StunPlayer(float time)
    {
        isStunned = true;
        yield return new WaitForSeconds(time);
        isStunned = false;
    }

    void TryToJump()
    {
        if (isTouchingGround)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(new Vector3(0f, jumpForce * rb.mass, 0f));
        GameManager.Instance.OnJump();
    }


    /// <summary>
    /// Sets the player in a boosted state
    /// </summary>
    void StartBoost()
    {
        acceleration = boostedAcceleration;
    }

    /// <summary>
    /// Sets the player in a not boosted state
    /// </summary>
    void StopBoost()
    {
        acceleration = normalAcceleration;
    }
}