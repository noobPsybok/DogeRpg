using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    private int renderBoundry;
	public Transform target; // Target of what to follow
	Camera myCam;
    private GameBoardCtrl gameBoard;
	
	// Use this for initialization
	void Start () {
		
		myCam = GetComponent<Camera>();
        gameBoard = GetComponent<GameBoardCtrl>();

        gameBoard.setupScene();
        renderBoundry = gameBoard.gridSize / 2;
	}
	
	// Update is called once per frame
	void Update () {
		
		// Keep a consistent size view ratio, no matter the screen size
		myCam.orthographicSize = Screen.height / 100f / 4f;
		
		if(target)
		{
			transform.position = Vector3.Lerp(transform.position, target.position, 0.2f) + new Vector3(0, 0, -10f);
		}

        /**************************************************
         * this generates a map based on your location    *
         * however it keeps regenerating one you exeed the*
         * renderBoundy so yea
         *************************************************/
        if (transform.position.x > renderBoundry || transform.position.y > renderBoundry)
        {
            gameBoard = GetComponent<GameBoardCtrl>();
            gameBoard.setupScene();
        }
		
	}
}