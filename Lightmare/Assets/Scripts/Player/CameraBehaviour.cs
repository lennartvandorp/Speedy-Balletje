using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] bool cameraMoveX;

    Vector3 standardOffset;
    // Start is called before the first frame update
    void Start()
    {
        standardOffset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraMoveX)
        {
            transform.position = standardOffset + player.position;
        }
        else
        {
            transform.position = new Vector3(0f, standardOffset.y + player.position.y, standardOffset.z + player.position.z);
        }
    }
}
