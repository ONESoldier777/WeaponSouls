//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using UnityEngine;

//namespace Assets.Scripts
//{
//    public class Chunk
//    {
//        public int[,] Blocks;
//        List<Vector3> vertices = new List<Vector3>();
//        List<int> triangles = new List<int>();
//        List<Vector2> uvs = new List<Vector2>();

//        public Chunk(int xSize, int ySize)
//        {
//            Blocks = new int[xSize, ySize];
//        }

//        void CreateBlock(int x, int y, int textureAtlasIndex)
//        {
//            vertices.Add(new Vector3(x, y, 0));
//            vertices.Add(new Vector3(x + 1, y, 0));
//            vertices.Add(new Vector3(x + 1, y - 1, 0));
//            vertices.Add(new Vector3(x, y - 1, 0));

//            triangles.Add(squareCount * 4);
//            triangles.Add((squareCount * 4) + 1);
//            triangles.Add((squareCount * 4) + 3);
//            triangles.Add((squareCount * 4) + 1);
//            triangles.Add((squareCount * 4) + 2);
//            triangles.Add((squareCount * 4) + 3);

//            uvs.Add(new Vector2(tUnit * texture.x, tUnit * texture.y + tUnit));
//            uvs.Add(new Vector2(tUnit * texture.x + tUnit, tUnit * texture.y + tUnit));
//            uvs.Add(new Vector2(tUnit * texture.x + tUnit, tUnit * texture.y));
//            uvs.Add(new Vector2(tUnit * texture.x, tUnit * texture.y));

//            squareCount++;
//        }
//    }
//}
