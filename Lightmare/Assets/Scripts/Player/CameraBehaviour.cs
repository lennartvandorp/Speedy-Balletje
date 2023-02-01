using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] Transform player;
    Rigidbody playerRb;

    [Range(0f, 1f)]
    [SerializeField] float distMult;
    [SerializeField] float maxAddedDistance;

    Vector3 standardOffset;

    // Start is called before the first frame update
    void Start()
    {
        standardOffset = transform.position - player.position;
        playerRb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GivePlayerHeadStart();
    }

    private void GivePlayerHeadStart()
    {
        float distanceBySpeed = playerRb.velocity.z * distMult;
        if (distanceBySpeed > maxAddedDistance) { distanceBySpeed = maxAddedDistance; }
        transform.position = player.position + standardOffset + new Vector3(0f, 0f, -distanceBySpeed);
    }
}