using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.Code.Interfaces;

namespace Assets.Code.States
{
	public class PlayState : IGameState
	{
		private StateManager manager;

		public NotificationsManager Notifications;


		public float input_x;
		public float input_y;
		public bool isNotMoving;

		public PlayState (StateManager managerRef)
		{
			manager = managerRef;
			Notifications = manager.NotificationRef;
			if (Application.loadedLevelName != "Play") 
			{
				Application.LoadLevel("Play");
				ShowIt();
			}

		}

		public void StateUpdate ()
		{
			input_x = Input.GetAxisRaw("Horizontal");
			input_y = Input.GetAxisRaw("Vertical");
			if(Mathf.Abs(input_x) > 0 || Mathf.Abs(input_y) > 0)
				Notifications.PostNotification(manager ,"onPlayerMove") ;

		}

		public void ShowIt ()
		{
			Debug.Log("Hello from PlayState");
		}

		public void StateGui ()
		{
			Debug.Log ("you did something with the gui");
		}
	}
}