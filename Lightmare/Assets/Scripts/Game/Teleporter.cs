using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] Transform target;
    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, target.position - transform.position, Color.magenta);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Teleport");
            other.transform.position = target.position;
            other.GetComponent<PlayerController>().ResetTarget();
        }
    }
}
