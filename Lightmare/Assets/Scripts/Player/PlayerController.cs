using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] float sensitivity;
    [SerializeField] float maxSpeed;
    [SerializeField] float clampOffset;
    [SerializeField] float acceleration;//the acceleration in the z direction
    [SerializeField] float stunTime;

    float targetOffset;
    Vector3 mouseMovement;
    Vector3 lastMousePos;
    Vector3 startPosition;
    Rigidbody rb;
    float finishDrag = 2;
    float normalDrag;

    bool active;
    bool isStunned;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        StartGame();//remove when events are properly implemented
        normalDrag = rb.drag;

        #region events
        GameManager.Instance().failGame += ResetPosition;
        GameManager.Instance().finishGame += Finish;
        GameManager.Instance().restart += ResetPosition;
        GameManager.Instance().stunPlayer += GetStunned;
        #endregion
    }

    bool isClicked;
    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            rb.AddForce(new Vector3(0f, 0f, acceleration * 100f * rb.mass * Time.deltaTime));
            if (Input.GetMouseButton(0) && !isStunned)//While clicked
            {
                if (!isClicked)
                {
                    targetOffset = transform.position.x;
                    target.position = transform.position;
                    isClicked = true;
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
            else if (isClicked)
            {
                targetOffset = transform.position.x;
                target.position = transform.position;
                isClicked = false;
            }

            lastMousePos = Input.mousePosition;
            if (transform.position.y < 0f)
            {
                GameManager.Instance().Fail();
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
}