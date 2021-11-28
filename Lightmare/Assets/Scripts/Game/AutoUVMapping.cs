using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DIYDebug;

public class AutoUVMapping : MonoBehaviour
{
    MeshFilter filter;
    Mesh mesh;
    [SerializeField] Vector2 textureSize;

    List<Vector3> triangles;
    [SerializeField] Transform testSphere;

    // Start is called before the first frame update
    void Start()
    {
        filter = GetComponent<MeshFilter>();
        mesh = filter.mesh;
    }

    private void Update()
    {
        UpdateUV();
    }

    private void UpdateUV()
    {
        triangles = TrianglesToVector3List();

        filter.mesh = mesh;//Actually updates the mesh which I would probably forget
    }


    List<Vector3> TrianglesToVector3List()
    {
        List<Vector3> newTriangles = new List<Vector3>();
        for (int i = 0; i < mesh.triangles.Length; i += 3)
        {
            newTriangles.Add(new Vector3Int(mesh.triangles[i], mesh.triangles[i + 1], mesh.triangles[i + 2]));
            if (i == 3)
            {
                testSphere.position = VertexWorldPosition(i);
            }
        }
        return newTriangles;
    }

    Vector3 VertexWorldPosition(int point)
    {
        return (Vector3.Scale(mesh.vertices[point], transform.lossyScale) + transform.position);
    }

}
