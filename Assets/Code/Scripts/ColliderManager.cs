using UnityEngine;
using System.Collections;

public class ColliderManager : MonoBehaviour 
{
	public Transform thisPos;
	public Vector3 cachePos;
	public float Gds;

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

		thisPos = gameObject.transform;
		cachePos = thisPos.position;
		Gds = boardRef.Gds;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log(other.name + this.gameObject);
	}

	public void GoRight ()
	{
		Gds = boardRef.Gds;
		cachePos = new Vector3(Gds,0f,0f);
		Debug.Log("new Cache = " + cachePos );
	}
}
