using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	public float camSize = 100f;
	public float camSize2 = 4f;
	public float camSpeed = 0.1f;
	public Transform target;
	
	Camera myCam;
	StateManager manager;
	NotificationsManager notifications;

	void Awake ()
	{
		manager = GameObject.Find("GameManager").GetComponent<StateManager>();
		notifications = manager.NotificationRef;
		notifications.AddListener(this ,"onPlayerMove");
	}
	// Use this for initialization
	void Start () 
	{
		myCam = gameObject.GetComponent<Camera>();
		//myCam.orthographicSize = (Screen.height/ camSize / camSize2);
	}
	
	// Update is called once per frame

	void Update () 
	{	
		myCam.orthographicSize = (Screen.height/ camSize / camSize2);
		/*
		if (target)
		{
			transform.position =  Vector3.Lerp(transform.position, target.position, camSpeed) + new Vector3(0f,0f,-20f);
		}
		*/
	}

	public void onPlayerMove ()
	{
		transform.position = Vector3.Lerp (transform.position,target.position,camSpeed) + new Vector3(0f,0f,-20f);
	}
}

