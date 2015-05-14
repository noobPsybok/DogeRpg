using UnityEngine;
using System.Collections;

public class ContainerController : MonoBehaviour 
{
	public StateManager manager;
	public NotificationsManager notifications;
	public BoxCollider2D thisCollider;
	// Use this for initialization
	void Start () 
	{
		manager = GameObject.Find ("GameManager").GetComponent<StateManager> ();
		notifications = manager.NotificationRef;
		thisCollider = gameObject.GetComponent<BoxCollider2D> ();

		notifications.PostNotification(gameObject.transform.position,"newBoard");
	}
	
	// Update is called once per frame
	void Update () 
	{	
	}

	void OnTriggerExit2D(Collider2D other)
	{
		notifications.PostNotification(gameObject.transform.position,"boardDestroyed");
		if (other.CompareTag ("Player"))
			Destroy (gameObject);

	}
}
