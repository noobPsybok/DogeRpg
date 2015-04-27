using UnityEngine;
using System;
using System.Collections.Generic;  // lets us use lists
using Random = UnityEngine.Random; // tells Random to use Unity Engine random number generator

public class GameBoardCtrl : MonoBehaviour 
{
	public float tileSize = 0.4f; // the size of our tiles wich will be used to increment floor space acordingly
	public int gridSize = 10; // the dimensions of our square board to be rendered 
	public GameObject[] floorTiles; // out list of floor tiles to be used

    Vector3 boardPosition;
	private List <Vector3> gridPositions = new List <Vector3> (); //A list of possible locations to place tiles.
    private Transform boardHolder;

	//sets up a list of possible grid positions
	void initialiseGrid()
	{
        gridPositions.Clear();
        boardPosition = transform.position;

        int i, j;
		float x;
		float y;

        //sets the grid positions as a function of the camera postion so that new terrain can be generated after the initial start
		for( x = boardPosition.x, i = -gridSize ;i < gridSize; i++)
		{
			for( y = boardPosition.y, j = -gridSize ; j < gridSize; j++)
			{

                gridPositions.Add(new Vector3(x + (i * tileSize), y + (j * tileSize), 0));
			}
		}
	}

	void setBoard ()
	{
        boardHolder = new GameObject("board").transform;

		foreach (Vector3 step in gridPositions)
		{
            //randomly select wich floorTiles we are going to instantiate
            GameObject toInstatiate = floorTiles[Random.Range(0, floorTiles.Length)];

            //instantiate the random floor tile, set its position to the index vector3 "step" and set the orientation to normal
            GameObject instance = Instantiate(toInstatiate, step, Quaternion.identity) as GameObject;

            //Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.
            instance.transform.SetParent(boardHolder);
		}
	}

    public void setupScene()
    {
        
        //calls initialisegrid method to generate the grid list
        initialiseGrid();
        if (boardHolder != null)
        {
            Destroy(GameObject.Find("board"));
        }

        //call setBoard method to setup the board
        setBoard();
    }
}