using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bebou : MonoBehaviour
{
    [SerializeField] private MeshFilter meshFilter;
    [SerializeField, Range(0, 10)] private float offset;

    const string jsonCube = "{\r\n  \"vertices\": [\r\n    { \"x\": -1, \"y\": -1, \"z\": -1 }, // Sommet 0\r\n    { \"x\": 1, \"y\": -1, \"z\": -1 },  // Sommet 1\r\n    { \"x\": 1, \"y\": 1, \"z\": -1 },   // Sommet 2\r\n    { \"x\": -1, \"y\": 1, \"z\": -1 },  // Sommet 3\r\n    { \"x\": -1, \"y\": -1, \"z\": 1 },  // Sommet 4\r\n    { \"x\": 1, \"y\": -1, \"z\": 1 },   // Sommet 5\r\n    { \"x\": 1, \"y\": 1, \"z\": 1 },    // Sommet 6\r\n    { \"x\": -1, \"y\": 1, \"z\": 1 }    // Sommet 7\r\n  ],\r\n  \"triangles\": [\r\n    0, 1, 2, 2, 3, 0, // Face avant\r\n    4, 5, 6, 6, 7, 4, // Face arrière\r\n    0, 4, 7, 7, 3, 0, // Côté gauche\r\n    1, 5, 6, 6, 2, 1, // Côté droit\r\n    0, 1, 5, 5, 4, 0, // Face inférieure\r\n    2, 6, 7, 7, 3, 2  // Face supérieure\r\n  ]\r\n}\r\n";

    [System.Serializable]
    private class JsonStruct
    {
        public Vector3[] vertices;
        public int[] triangles;
    }

    private Mesh mesh;
    private Vector3[] vertices;
    private Vector3[] initialVertices;


    private void Awake()
    {
        //Debug.Log(string.Join<int>(" ", meshFilter.mesh.triangles));
        //Debug.Log(string.Join<Vector3>(" ", meshFilter.mesh.vertices));


        JsonStruct myCubeStruct = JsonUtility.FromJson<JsonStruct>(jsonCube);

        mesh = new Mesh();
        mesh.vertices = myCubeStruct.vertices;
        mesh.triangles = myCubeStruct.triangles;

        meshFilter.mesh = mesh;
    }

    //private void Update()
    //{
    //    mesh = meshFilter.mesh;

    //    Debug.Log(string.Join<int>(" ", mesh.triangles));
    //    Debug.Log(mesh.triangles.Length);

    //    vertices = mesh.vertices;

    //    for (int i = 0; i < vertices.Length; i++)
    //    {
    //        vertices[i] = initialVertices[i] + mesh.normals[i] * offset;
    //    }

    //    mesh.SetVertices(vertices);
    //    mesh.UploadMeshData(false);
    //    mesh.RecalculateBounds();
    //}
}
