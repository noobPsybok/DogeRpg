using UnityEngine;
using Assets.Code.Interfaces;
using Assets.Code.States;

public class StateManager : MonoBehaviour 
{
	[HideInInspector]
	public GameData gameDataRef;
	[HideInInspector]
	public NotificationsManager NotificationRef;

	private IGameState activeState;
	public static StateManager instanceRef;

	void Awake ()
	{
		if (instanceRef == null) 
		{
			instanceRef = this;
			DontDestroyOnLoad (gameObject);
		} 
		else 
		{
			DestroyImmediate(gameObject);
		}
	}
	// Use this for initialization
	void Start () 
	{
		activeState = new BeginState (this);
		gameDataRef = GetComponent<GameData> ();
		NotificationRef = GetComponent<NotificationsManager> ();
		activeState.ShowIt();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (activeState != null) {
			activeState.StateUpdate ();
		}
	}

	public void GuiGuru ()
	{
		activeState.StateGui ();
	}

	public void SwitchState(IGameState newState)
	{
		activeState = newState;
	}

	public void levelWasLoaded ()
	{

	}

	public void Restart()
	{
		Destroy (gameObject);
		Application.LoadLevel ("StartUP");
	}
}
