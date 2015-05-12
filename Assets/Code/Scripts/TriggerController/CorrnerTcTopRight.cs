using UnityEngine;
using System.Collections;

public class CorrnerTcTopRight : MonoBehaviour 
{
	public Transform parentTransform;
	
	public StateManager manager;
	public NotificationsManager notifications;
	public BoardController board;
	
	private BoxCollider2D thisCollider = null;
	
	public int gridSize;
	public float tileSize;
	public float Gds;
	
	public Vector2 thisOffset;
	public Vector2 thisSize;
	
	// Use this for initialization
	void Start () 
	{
		manager = GameObject.Find("GameManager").GetComponent<StateManager>();
		notifications = manager.NotificationRef;
		
		parentTransform = GameObject.Find("GameController").GetComponent<Transform>();
		board = GameObject.Find("board").GetComponent<BoardController>();
		thisCollider = gameObject.GetComponent<BoxCollider2D>();
		
		gridSize = board.gridSize;
		tileSize = board.tileSize;
		Gds = board.Gds;
		
		thisOffset = new Vector2((tileSize*gridSize)+ (tileSize/2),(tileSize*gridSize)+ (tileSize/2));
		thisSize = new Vector2 ((tileSize*gridSize)+ tileSize, (tileSize*gridSize)+ tileSize);
		
		thisCollider.offset = thisOffset;
		thisCollider.size = thisSize;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player") )
		{
			//parentTransform.position += new Vector3(1f,1f,0f);
			notifications.PostNotification(this,"onBoardTopRight");
			Debug.Log(other.name + " " + this.gameObject + " " + parentTransform.position);
		}
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player") )
		{
			parentTransform.position += new Vector3(0,Gds,0);
			Debug.Log (other.name + " " + "has leaft");
		}
	}

}
