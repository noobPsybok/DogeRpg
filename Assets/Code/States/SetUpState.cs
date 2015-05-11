using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.Code.Interfaces;

namespace Assets.Code.States
{
	public class SetUpState : IGameState
	{
		private StateManager manager;

		public SetUpState (StateManager managerRef)
		{
			manager = managerRef;
			if (Application.loadedLevelName != "SetUp") 
			{
				Application.LoadLevel("SetUp");
				ShowIt();
			}
		}

		public void StateUpdate ()
		{

		}

		public void ShowIt ()
		{
			Debug.Log("Hello from SetUpState");
		}

		public void StateGui ()
		{
			Debug.Log ("you did something with the gui");
			manager.SwitchState (new PlayState(manager) );
		}
	}
}