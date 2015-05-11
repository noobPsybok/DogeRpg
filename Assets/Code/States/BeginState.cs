using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.Code.Interfaces;

namespace Assets.Code.States
{
	public class BeginState :  IGameState
	{
		private StateManager manager;
		private Canvas splashScreen;


		public BeginState (StateManager managerRef)
		{
			manager = managerRef;
			if (Application.loadedLevelName != "StartUP") 
			{
				Application.LoadLevel ("StartUP");
				ShowIt();
			}
		}

		public	void StateUpdate ()
		{
			if (Input.anyKeyDown)
			{ 
				Debug.Log("you pressed something");
				manager.SwitchState(new SetUpState (manager) );
			}	
		}

		public void ShowIt ()
		{
			splashScreen = Canvas.Instantiate(manager.gameDataRef.BeginStateSplash);
			
		}
		public void StateGui ()
		{
			splashScreen = manager.gameDataRef.BeginStateSplash;
			Canvas.Instantiate (splashScreen);
		}
	}
}