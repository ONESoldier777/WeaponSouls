﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PolygonGenerator : MonoBehaviour {
	// This first list contains every vertex of the mesh that we are going to render
	public List<Vector3> newVertices = new List<Vector3>();

	// The triangles tell Unity how to build each section of the mesh joining
	// the vertices
	public List<int> newTriangles = new List<int>();

	// The UV list is unimportant right now but it tells Unity how the texture is
	// aligned on each polygon
	public List<Vector2> newUV = new List<Vector2>();

	// A mesh is made up of the vertices, triangles and UVs we are going to define,
	// after we make them up we'll save them as this mesh
	private Mesh mesh;

	private float tUnit = 0.25f;
	private Vector2 tStone = new Vector2(1, 0);
	private Vector2 tGrass = new Vector2(0, 1);

	private int squareCount;

	public byte[,] blocks;

	void UpdateMesh()
	{
		mesh.Clear();
		mesh.vertices = newVertices.ToArray();
		mesh.triangles = newTriangles.ToArray();
		mesh.uv = newUV.ToArray();
		mesh.Optimize();
		mesh.RecalculateNormals();

		squareCount = 0;
		newVertices.Clear();
		newTriangles.Clear();
		newUV.Clear();
	}

	void GenSquare(int x, int y, Vector2 texture)
	{
		newVertices.Add(new Vector3(x, y, 0));
		newVertices.Add(new Vector3(x + 1, y, 0));
		newVertices.Add(new Vector3(x + 1, y - 1, 0));
		newVertices.Add(new Vector3(x, y - 1, 0));

		newTriangles.Add(squareCount * 4);
		newTriangles.Add(squareCount * 4 + 1);
		newTriangles.Add(squareCount * 4 + 3);
		newTriangles.Add(squareCount * 4 + 1);
		newTriangles.Add(squareCount * 4 + 2);
		newTriangles.Add(squareCount * 4 + 3);

		newUV.Add(new Vector2(tUnit * texture.x, tUnit * texture.y + tUnit));
		newUV.Add(new Vector2(tUnit * texture.x + tUnit, tUnit * texture.y + tUnit));
		newUV.Add(new Vector2(tUnit * texture.x + tUnit, tUnit * texture.y));
		newUV.Add(new Vector2(tUnit * texture.x, tUnit * texture.y));
	}

	void GenTerrain()
	{
		blocks = new byte[10, 10];

		for (int px = 0; px < blocks.GetLength(0); px++)
		{
			for (int py = 0; py < blocks.GetLength(1); py++)
			{
				if (py == 5)
				{
					blocks[px, py] = 2;
				}
				else if (py < 5)
				{
					blocks[px, py] = 1;
				}
			}
		}
	}

	void BuildMesh()
	{
		for (int px = 0; px < blocks.GetLength(0); px++)
		{
			for (int py = 0; py < blocks.GetLength(1); py++)
			{

				if (blocks[px, py] == 1)
				{
					GenSquare(px, py, tStone);
				}
				else if (blocks[px, py] == 2)
				{
					GenSquare(px, py, tGrass);
				}

			}
		}
	}

	// Use this for initialization
	void Start () {
		mesh = GetComponent<MeshFilter>().mesh;
		GenTerrain();
		BuildMesh();
		UpdateMesh();
	}
	
	// Update is called once per frame
	void Update () {
		//UpdateMesh();
	}
}
