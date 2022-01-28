using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] Transform player;
    float lerpSpeed = 30f;
    float maxXVelocity = 2f;

    Vector3 standardOffset;

    // Start is called before the first frame update
    void Start()
    {
        standardOffset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = player.position + standardOffset;
        Vector3 velocity = targetPos - transform.position;
        

        if (velocity.x > maxXVelocity){velocity = new Vector3(maxXVelocity, velocity.y, velocity.z);}//So horizontal movement is better readable, especially when teleporting
        else if(velocity.x < -maxXVelocity) { velocity = new Vector3(-maxXVelocity, velocity.y, velocity.z); }
        transform.position += velocity * Time.deltaTime * lerpSpeed;
        if(velocity.magnitude * Time.deltaTime * lerpSpeed > velocity.magnitude)
        {
            transform.position = targetPos;//To counteract a feedback loop where the camera shoots off into the distance. 
        }
        //transform.position = new Vector3(targetPos.x, transform.position.y, transform.position.z);
    }
}