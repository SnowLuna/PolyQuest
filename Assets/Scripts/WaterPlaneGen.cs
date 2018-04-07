using System.Collections.Generic;
using UnityEngine;

public class WaterPlaneGen : MonoBehaviour {

    public float size;
    public int gridSize;

    private MeshFilter filter;

	void Start () {
        filter = GetComponent<MeshFilter>();
        filter.mesh = GenerateMesh();
	}

    public Mesh GenerateMesh()
    {
        Mesh m = new Mesh();
        List<Vector3> verticies = new List<Vector3>();
        List<Vector3> normals = new List<Vector3>();
        List<Vector2> uvs = new List<Vector2>();
        float gridSizeFloat = (float)gridSize;

        for (int x = 0; x <= gridSize; x++)
        {
            for(int y = 0; y <= gridSize; y++)
            {
                verticies.Add(new Vector3(-size * 0.5f + size * (x / gridSizeFloat), 0, -size * 0.5f + size * (y / gridSizeFloat)));
                normals.Add(Vector3.up);
                uvs.Add(new Vector2(x / gridSizeFloat, y / gridSizeFloat));
            }
        }

        List<int> triangles = new List<int>();
        int verticlesCount = gridSize + 1;
        for(int i = 0; i < verticlesCount * verticlesCount - verticlesCount; i++)
        {
            if((i+1) % verticlesCount == 0)
                continue;
            triangles.AddRange(new List<int>()
            {
                i + 1 + verticlesCount, i + verticlesCount, i,
                i, i + 1, i + verticlesCount + 1
            });
        }

        m.SetVertices(verticies);
        m.SetNormals(normals);
        m.SetUVs(0, uvs);
        m.SetTriangles(triangles, 0);
        return m;
    }
}
