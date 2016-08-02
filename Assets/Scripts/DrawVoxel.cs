using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawVoxel : MonoBehaviour
{
    Mesh mesh;
    List<Vector3> vertices = new List<Vector3>();
    List<int> triangles = new List<int>();
    List<Vector2> uvs = new List<Vector2>();

    void CreateBlock(int x, int y)
    {
        triangles.Add(vertices.Count);
        triangles.Add(vertices.Count+1);
        triangles.Add(vertices.Count+2);
        triangles.Add(vertices.Count);
        triangles.Add(vertices.Count+2);
        triangles.Add(vertices.Count+3);

        vertices.Add(new Vector3(x, y, 0));
        vertices.Add(new Vector3(x, y + 1, 0));
        vertices.Add(new Vector3(x + 1, y + 1, 0));
        vertices.Add(new Vector3(x + 1, y, 0));        
    }

    // Use this for initialization
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;

        for (int x = 0; x < 100; x++)
        {
            for (int y = 0; y < 30; y++)
            {
                CreateBlock(x,y);
            }
        }

        //uvs.Add(new Vector2(tUnit * texture.x, tUnit * texture.y + tUnit));
        //uvs.Add(new Vector2(tUnit * texture.x + tUnit, tUnit * texture.y + tUnit));
        //uvs.Add(new Vector2(tUnit * texture.x + tUnit, tUnit * texture.y));
        //uvs.Add(new Vector2(tUnit * texture.x, tUnit * texture.y));

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.Optimize();
        mesh.RecalculateNormals();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
