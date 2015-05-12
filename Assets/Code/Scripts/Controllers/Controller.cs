using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour 
{
	private StateManager manager;

	void Awake ()
	{
		manager = GameObject.Find ("GameManager").GetComponent<StateManager> ();
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ControllerGui ()
	{
		manager.GuiGuru ();
	}

	public void ControllerRestart ()
	{
		manager.Restart ();
	}
}
