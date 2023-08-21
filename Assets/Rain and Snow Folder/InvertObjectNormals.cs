using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class InvertObjectNormals : MonoBehaviour
{
    public GameObject SferaPanoramica;

    void Awake()
    {
     //   SferaPanoramica = this.gameObject;    
      //  InvertSphere();
    }
    private void Start()
    {
    /*    Mesh mesh = this.GetComponent<MeshFilter>().mesh;
        Vector3[] normals = mesh.normals;
        for (int i = 0; i < normals.Length; i++)
            normals[i] = -1 * normals[i];
        mesh.normals = normals;
        for (int i = 0; i < mesh.subMeshCount; i++)
        {
            int[] tris = mesh.GetTriangles(i);
            for (int j = 0; j < tris.Length; j += 3)
            {
                //swap order of tri vertices
                int temp = tris[j];
                tris[j] = tris[j + 1];
                tris[j + 1] = temp;
            }
            mesh.SetTriangles(tris, i);
        }
    */
     }

    void InvertSphere()
    {
        Vector3[] normals = SferaPanoramica.GetComponent<MeshFilter>().sharedMesh.normals;
        for (int i = 0; i < normals.Length; i++)
        {
            normals[i] = -normals[i];
        }
        SferaPanoramica.GetComponent<MeshFilter>().sharedMesh.normals = normals;

        int[] triangles = SferaPanoramica.GetComponent<MeshFilter>().sharedMesh.triangles;
        for (int i = 0; i < triangles.Length; i += 3)
        {
            int t = triangles[i];
            triangles[i] = triangles[i + 2];
            triangles[i + 2] = t;
        }

        SferaPanoramica.GetComponent<MeshFilter>().sharedMesh.triangles = triangles;
    }
    void OnApplicationQuit()
    {

    }
}