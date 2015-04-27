using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target; // Target of what to follow
	Camera myCam;//reference type wich store a reference to the camera game object
    GameBoardCtrl gameBoard;//reference to the GameBoardCtrl
    private int size;//variable wich will hold the value of the gridSize in Game
    private int pos_x;//variable which will hold the value of cameras x position
    private int pos_y;//variable which will hold the value of cameras y position

	// Use this for initialization
	void Start () 
    {
		myCam = GetComponent<Camera>();

        // Keep a consistent size view ratio, no matter the screen size
        myCam.orthographicSize = Screen.height / 100f / 4f;
        Debug.Log(myCam.orthographicSize);
        gameBoard = GetComponent<GameBoardCtrl>();

        size = gameBoard.gridSize;

        gameBoard.setupScene();
        
	}
	
	// Update is called once per frame
	void Update () {
		
		// Keep a consistent size view ratio, no matter the screen size
		myCam.orthographicSize = Screen.height / 100f / 4f;
        

        pos_x = (int)transform.position.x;
        pos_y = (int)transform.position.y;
		
		if(target)
		{
			transform.position = Vector3.Lerp(transform.position, target.position, 0.2f) + new Vector3(0, 0, -10f);
		}

        /**************************************************
         * this generates a map based on your location    *
         * however it keeps regenerating one you exeed the*
         * renderBoundy so yea. im gonna make this an event
         * eventually
         *************************************************/
        if (Mathf.Abs(pos_x) % size == (size /2) || Mathf.Abs(pos_y) % size == (size / 2))
        {
            gameBoard.setupScene();
        }
		
	}
}