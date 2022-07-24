using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshTester : MonoBehaviour
{
    [Header("initial vertex array")]
    [Tooltip("starting vertex arrays")]
    public Vector3[] newVertices;
    public Vector2[] newUV;
    public int[] newTriangles;


    // Start is called before the first frame update
    void Start()
    {
        //Creates the base for a new Mesh that will be input into the MeshFilter component
        Mesh mesh = new Mesh();

        //Adds both the MeshFilter and MeshRenderer components to the attached gameObject
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();

        //Creates a local variable that addresses our MeshRenderer component attached to this gameObject
        MeshRenderer myMeshRenderer = gameObject.GetComponent<MeshRenderer>();

        //Creates a local variable that addresses our MeshFilter component attached to this gameObject
        MeshFilter myMesh = gameObject.GetComponent<MeshFilter>();

        //Assigns the local variable above to the Mesh that we constructed in this Start function.
        myMesh.mesh = mesh;

        //Assigns the MeshRenderer.material property to the standard material
        myMeshRenderer.material = new Material(Shader.Find("Standard"));

        //Create a normals array and fill the values with normals facing in the negative Z direction
        /*Vector3[] newNormals = new Vector3[4]
        {
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward
        };*/

        mesh.vertices = newVertices;
        mesh.uv = newUV;
        mesh.triangles = newTriangles;
        //mesh.normals = newNormals;
    }

    // Update is called once per frame
    void Update()
    {
        //Get the Mesh component from the game object once per frame
        Mesh mesh = gameObject.GetComponent<MeshFilter>().mesh;

        //Set the mesh's vertices equal to the Global public variable newVertices
        //Which will allow for live updating of mesh generation
        mesh.vertices = newVertices;
    }
}
