using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoUVMapping : MonoBehaviour
{
    Mesh mesh;
    [SerializeField] Vector2 textureSize;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            Vector3 relativePos = Vector3.Scale(mesh.vertices[i], transform.lossyScale);
            Debug.Log(relativePos);
        }

        GetComponent<MeshFilter>().mesh = mesh;
    }


}
