using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColliderManager : MonoBehaviour 
{
	public Transform thisPos;
	public Vector3 cachePos;
	public float Gds;

	public List<Vector3> boardSpots = new List<Vector3>();

	public StateManager manager;
	public NotificationsManager notifications;
	public BoardController boardRef;


	// Use this for initialization
	void Start () 
	{
		manager = GameObject.Find("GameManager").GetComponent<StateManager>();
		notifications = manager.NotificationRef;
		boardRef = gameObject.GetComponent<BoardController>();

		notifications.AddListener(this,"GoRight");
		notifications.AddListener(this,"GoLeft");
		notifications.AddListener(this,"GoUp");
		notifications.AddListener(this,"GoDown");
		notifications.AddListener(this,"GoTopRight");
		notifications.AddListener(this,"newBoard");
		notifications.AddListener(this,"boardDestroyed");
		notifications.AddListener(this,"GoBack");

		thisPos = gameObject.transform;
		cachePos = thisPos.position;
		Gds = boardRef.Gds;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void newBoard (Vector3 boardSpot)
	{
		boardSpots.Add(boardSpot);
	}

	public void boardDestroyed (Vector3 boardSpot)
	{
		boardSpots.Remove(boardSpot);
		thisPos.position = boardSpots[0];
		cachePos = boardSpots[0];
	}

	public void GoBack ()
	{
		cachePos = boardSpots[0];
	}

	public void GoRight ()
	{
		if(Gds == 0)
			Gds = boardRef.Gds;
		cachePos += new Vector3(Gds,0f,0f);
		Debug.Log("new Cache = " + cachePos );
	}

	public void GoLeft ()
	{
		if(Gds == 0)
			Gds = boardRef.Gds;
		cachePos += new Vector3(-Gds,0f,0f);
		Debug.Log("new Cache = " + cachePos );
	}

	public void GoUp ()
	{
		if(Gds == 0)
			Gds = boardRef.Gds;
		cachePos += new Vector3(0f,Gds,0f);
		Debug.Log("new Cache = " + cachePos );
	}

	public void GoDown ()
	{
		if(Gds == 0)
			Gds = boardRef.Gds;
		cachePos += new Vector3(0f,-Gds,0f);
		Debug.Log("new Cache = " + cachePos );
	}

	public void GoTopRight ()
	{
		GoUp();
		GoLeft();
		GoDown();
	}
}
