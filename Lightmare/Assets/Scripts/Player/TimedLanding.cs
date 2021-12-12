using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Senses))]
[RequireComponent(typeof(PlayerController))]
public class TimedLanding : MonoBehaviour
{
    [SerializeField] private float timeToPress;

    Senses senses;
    PlayerController controller;

    // Start is called before the first frame update
    void Start()
    {
        senses = GetComponent<Senses>();
        controller = GetComponent<PlayerController>();
    }

    bool wasTouchingGround;
    bool wasTouchingScreen;
    // Update is called once per frame
    void Update()
    {

        if (!wasTouchingGround && senses.IsTouchingGround)
        {
            StartCoroutine(LandFirst());
        }
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(TouchFirst());
        }
        wasTouchingGround = senses.IsTouchingGround;
    }

    /// <summary>
    /// Run when the player lands on the ground
    /// </summary>
    /// <returns></returns>
    private IEnumerator LandFirst()
    {
        if (Input.GetMouseButton(0))
        {
            yield break;
        }
        float time = 0f;
        while (time < timeToPress)
        {
            if (Input.GetMouseButtonDown(0))
            {
                WellTimedLanding();
            }
            time += Time.deltaTime;
            yield return null;
        }
        yield return null;
    }


    /// <summary>
    /// Run when the player touches the screen
    /// </summary>
    /// <returns></returns>
    private IEnumerator TouchFirst()
    {

        if (wasTouchingGround)
        {
            yield break;
        }
        float time = 0f;
        while (time < timeToPress)
        {
            if (wasTouchingGround)
            {
                WellTimedLanding();
            }
            time += Time.deltaTime;
            yield return null;
        }
        yield return null;
        yield return null;
    }


    /// <summary>
    /// When well timed landing is successful
    /// </summary>
    void WellTimedLanding()
    {
        GameManager.Instance.LandBoost();
    }
}
