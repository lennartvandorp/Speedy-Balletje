using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] Transform player;
    float lerpSpeed = 50f;

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
        transform.position += velocity * Time.deltaTime * lerpSpeed;
        transform.position = new Vector3(targetPos.x, transform.position.y, transform.position.z);
    }
}
