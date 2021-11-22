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
        mesh = GetComponent<Mesh>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
