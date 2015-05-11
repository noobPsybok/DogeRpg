using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class TriggerMap : MonoBehaviour
{
    public List<Vector3> triggerPositions = new List<Vector3>();
    public Vector3 boardPosition;
    int gridSize = BoardController.gridSize;
    float tileSize = BoardController.tileSize;

    public TriggerMap()
    {
        boardPosition = new Vector3(0f, 0f, 0f);

        float x, y, inv_x, inv_y;

        x = (gridSize * tileSize);
        y = (gridSize * tileSize);
        inv_x = -(gridSize * tileSize);
        inv_y = -(gridSize * tileSize);

        triggerPositions.Add(new Vector3(x, 0f, 0f));
        triggerPositions.Add(new Vector3(0f, y, 0f));
        triggerPositions.Add(new Vector3(inv_x, 0f, 0f));
        triggerPositions.Add(new Vector3(0f, inv_y, 0f));
    }

    public TriggerMap(Vector3 boardPos)
    {
        triggerPositions.Clear();
        float i, j;

        boardPosition = boardPos;

        i = boardPosition.x;
        j = boardPosition.y;

        float x, y, inv_x, inv_y;

        x = (gridSize * tileSize);
        y = (gridSize * tileSize);
        inv_x = -(gridSize * tileSize);
        inv_y = -(gridSize * tileSize);

        triggerPositions.Add(new Vector3(x + i, 0f, 0f));
        triggerPositions.Add(new Vector3(0f, y + j, 0f));
        triggerPositions.Add(new Vector3(inv_x + i, 0f, 0f));
        triggerPositions.Add(new Vector3(0f, inv_y + j, 0f));
    }
}

