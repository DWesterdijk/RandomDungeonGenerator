using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class MapGenerator : MonoBehaviour {

    public int width;
    public int height;

    public int randomNumber;

    public string seed;
    public bool useRandomSeed;
    
    public int fillPercent;

    int[,] map;

    private void Start()
    {
        randomNumber = Random.Range(0, 100000);

        GenerateMap();
    }

    void GenerateMap()
    {
        map = new int[width, height];
        RandomFillMap();

        for (int i = 0; i < 4; i++)
        {
            SmoothMap();
        }
    }

    void RandomFillMap()
    {
        if (useRandomSeed)
        {
            seed = randomNumber.ToString();
        }

        System.Random randomSeed = new System.Random(seed.GetHashCode());

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                {
                    map[x, y] = 1;
                }
                else
                {
                    map[x, y] = (randomSeed.Next(0, 100) < fillPercent) ? 1 : 0;
                }
            }
        }
    }

    void SmoothMap()
    {
        for (int x = 1; x < width; x++)
        {
            for (int y = 1; y < height; y++)
            {
                int neighbourWalls = GetNeightbourWall(x, y);

                if (neighbourWalls > 2)
                {
                    map[x, y] = 1;
                }
                else if (neighbourWalls < 2)
                {
                    map[x, y] = 0;
                }
            }
        }
    }

    int GetNeightbourWall(int gridX, int gridY)
    {
        int wallAmount = 0;
        for (int neighbourX = gridX; neighbourX <= gridX + 1; neighbourX++)
        {
            for (int neighbourY = gridY; neighbourY <= gridY + 1; neighbourY++)
            {
                if (neighbourX >= 0 && neighbourX < width && neighbourY >= 0 && neighbourY < height)
                {
                    if (neighbourX != gridX || neighbourY != gridY)
                    {
                        wallAmount += map[neighbourX, neighbourY];
                    }
                }
                else
                {
                    wallAmount++;
                }
            }
        }
        return wallAmount;
    }

    private void OnDrawGizmos()
    {
        if (map != null)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Gizmos.color = (map[x, y] == 1) ? Color.black : Color.white;
                    Vector3 pos = new Vector3(-width / 2 + x + .5f, -height / 2 + y + .5f);
                    Gizmos.DrawCube(pos, Vector3.one);
                }
            }
        }
    }
}
