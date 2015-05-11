using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardController : MonoBehaviour
{
	public Vector3 myPos;
	public GameObject boardContainer;
	public GameObject[] tile;

	private PlayerController player;
	private Vector3 playerPos;

	public int gridSize = 8;
	public float tileSize = 0.4f;
	public float Gds;//GridDirectionScalar
	public int direction;

	public StateManager manager;
	public NotificationsManager notifications;

	public ColliderManager colliders;
	public Vector3 collidersPos;

	void Awake ()
	{

		manager = GameObject.Find("GameManager").GetComponent<StateManager>();
		notifications = manager.NotificationRef;

		myPos = gameObject.transform.position;

	}
	// Use this for initialization
	void Start () 
	{
		notifications.AddListener(this,"onBoardRight");
		notifications.AddListener(this,"onBoardLeft");
		notifications.AddListener(this,"onBoardUp");
		notifications.AddListener(this,"onBoardDown");

		colliders = GameObject.Find("GameController").GetComponent<ColliderManager>();
		collidersPos = colliders.cachePos;
		Gds = ( 2 * ( (tileSize * gridSize) + (tileSize/2) ) );
		direction = 1;

		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		onPlayStart();
	}

	public List<Vector3> gridPoints = new List<Vector3>();
	public void makeGrid ()
	{
		int i,j;
		float gridOffSetX;
		float gridOffSetY;

		for(i = -gridSize; i <= gridSize; i++)
		{
			for (j = -gridSize ; j <= gridSize; j++)
			{
				gridOffSetX =(collidersPos.x + tileSize*i);
				gridOffSetY =(collidersPos.y + tileSize*j);
				gridPoints.Add(new Vector3(gridOffSetX,gridOffSetY,0f));
			}
		}

	}

	public void makeBoard()
	{
		GameObject ContainerInstance = GameObject.Instantiate(boardContainer,collidersPos,Quaternion.identity) as GameObject;

		foreach(Vector3 plot in gridPoints)
		{
			GameObject toInsantiate = tile[Random.Range((direction - 1),(direction + 1))];
			GameObject instance  = GameObject.Instantiate(toInsantiate,plot,Quaternion.identity) as GameObject;
			instance.transform.SetParent(ContainerInstance.transform);
		}
		gridPoints.Clear();
	}
	

	public void onPlayStart ()
	{
		makeGrid();
		makeBoard();
		Debug.Log("gridSize is" + gridPoints.Count );
		//setFirst grid
	}

	public void onBoardRight ()
	{
		if(tile.Length != direction + 1)
			direction += 1;
		else if(direction != 1)
			direction = 1;
		collidersPos += new Vector3 (Gds,0,0);
		makeGrid();
		makeBoard();
		Debug.Log("collisers new position is " + collidersPos );
	}

	public void onBoardLeft ()
	{
		if(tile.Length != direction + 1)
			direction += 1;
		else if(direction != 1)
			direction = 1;
		collidersPos += new Vector3 (-Gds,0,0);
		makeGrid();
		makeBoard();
	}

	public void onBoardUp()
	{
		if(tile.Length != direction + 1)
			direction += 1;
		else if(direction != 1)
			direction = 1;
		collidersPos += new Vector3 (0,Gds,0);
		makeGrid();
		makeBoard();
	}

	public void onBoardDown()
	{
		if(tile.Length != direction + 1)
			direction += 1;
		else if(direction != 1)
			direction = 1;
		collidersPos += new Vector3 (0,-Gds,0);
		makeGrid();
		makeBoard();
	}
}
