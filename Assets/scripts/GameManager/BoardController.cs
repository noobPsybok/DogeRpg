using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random; // tells Random to use Unity Engine random number generator

public class BoardController : MonoBehaviour 
{
    public GameObject[] floorTiles;
    public GameObject colliders;

    public static float tileSize = 0.4f;
    public static int gridSize = 16;
    public GridMap myGrid = new GridMap();
    public TriggerMap myTriggers = new TriggerMap();
    public List<Vector3> gridPlots;
    public List<Vector3> triggerPlots;

    private Transform boardHolder;
    private int boardPostition;

    public Test start = new Test();

    void setBoard()
    {
        gridPlots = myGrid.gridPositions;

        boardHolder = new GameObject("board").transform;
        boardHolder.transform.SetParent(start.transform);

        foreach (Vector3 step in gridPlots)
        {
            GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];

            GameObject instance = Instantiate(toInstantiate, step, Quaternion.identity) as GameObject;

            instance.transform.SetParent(boardHolder);
        }
    }

    public void setTriggers()
    {
        triggerPlots = myTriggers.triggerPositions;
        BoxCollider2D clone;
        foreach (Vector3 step in triggerPlots)
        {
            clone = Instantiate(colliders, step, Quaternion.identity) as BoxCollider2D;
            clone.size = new Vector2(Mathf.Abs(step.x), Mathf.Abs(step.y) );
        }
    }

    public void sceneSetup()
    {
        setBoard();

        setTriggers();


    }
}
