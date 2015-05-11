using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GridMap : MonoBehaviour
{
    public Vector3 boardPosition;

    public List<Vector3> gridPositions = new List<Vector3>();

    int gridSize = BoardController.gridSize;
    float tileSize = BoardController.tileSize;

    public GridMap()
    {     
        boardPosition = new Vector3(0, 0, 0);

        float x, y;


        for (x = -gridSize; x < gridSize; x++)
        {
            for (y = -gridSize; y < gridSize; y++)
            {
                gridPositions.Add(new Vector3(x * tileSize, y * tileSize, 0));
            }
        }
    }
    public GridMap(Vector3 board)
    {
        gridPositions.Clear();


        boardPosition = board;
        float DrawPoint_x;
        float DrawPoint_y;

        float x, y;
        DrawPoint_x = boardPosition.x;
        DrawPoint_y = boardPosition.y;

        for (x = -gridSize; x < gridSize; x++)
        {
            for (y = -gridSize; y < gridSize; y++)
            {
                gridPositions.Add(new Vector3(x * tileSize + DrawPoint_x, y * tileSize + DrawPoint_y, 0));
            }
        }
    }
}
