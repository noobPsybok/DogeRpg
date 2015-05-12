using UnityEngine;
using System.Collections;

public class ContainerController : MonoBehaviour 
{
	public StateManager manager;
	public BoxCollider2D thisCollider;
	// Use this for initialization
	void Start () 
	{
		manager = GameObject.Find ("GameManager").GetComponent<StateManager> ();
		thisCollider = gameObject.GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{	
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag ("Player"))
			Destroy (gameObject);

	}
}
