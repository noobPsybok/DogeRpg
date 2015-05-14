using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NotificationsManager : MonoBehaviour
{
	//Notification private  variables
	private Dictionary<string, List<Component>> Listeners = new Dictionary<string, List<Component>>();

	//Notification methods
	public void AddListener (Component Sender, string NotificationName)
	{
		//Add Listener to dictionary
		if (!Listeners.ContainsKey (NotificationName))
			Listeners.Add (NotificationName, new List<Component> ());

		//Add Object to list for this Notification
		Listeners [NotificationName].Add (Sender);
	}

	//Function to remove Listener for a notification
	public void RemoveListener( Component Sender,string NotificationName)
	{
		//if no key in dictionnary exists, then exit
		if (!Listeners.ContainsKey (NotificationName))
			return;
		//Cyclr Through listeners and identifiy component, and then remove it
		for (int i = Listeners[NotificationName].Count - 1; i>=0; i--) 
		{
			//Check instance id if match remove from list
			if(Listeners[NotificationName][i].GetInstanceID() == Sender.GetInstanceID())
				Listeners[NotificationName].RemoveAt(i);
		}
	}

	//Function to post a notification to a listener
	public void PostNotification(Component Sender, string NotificationName)
	{
		//if no key in dictionary exists, then exit
		if (!Listeners.ContainsKey (NotificationName))
			return;

		//else post notification to all matching listenters
		foreach (Component Listener in Listeners[NotificationName])
			Listener.SendMessage (NotificationName, SendMessageOptions.DontRequireReceiver);
	}

	public void PostNotification(Vector3 SenderVector, string NotificationName)
	{
		//if no key in dictionary exists, then exit
		if (!Listeners.ContainsKey (NotificationName))
			return;
		
		//else post notification to all matching listenters
		foreach (Component Listener in Listeners[NotificationName])
			Listener.SendMessage (NotificationName,SenderVector, SendMessageOptions.DontRequireReceiver);
	}

	//Function to clear all Listeners
	public void ClearListeners()
	{
		//Removes all listeners
		Listeners.Clear ();
	}

	//Function to remove Redundant Listeners - Deleted and removed listeners
	public void RemoveRedundancies()
	{
		//Create new Dictionary
		Dictionary<string,List<Component>> tmpListeners = new Dictionary<string, List<Component>> ();

		//cycle through all dictionary entries
		foreach (KeyValuePair<string, List<Component>> Item in Listeners) 
		{
			//cycle though all listeners objects in list, remove null objects
			for(int i = Item.Value.Count - 1;i >= 0;i--)
			{
				//if nullthen remove item
				if(Item.Value[i] == null)
					Item.Value.RemoveAt(i);
			}
			// if item remain in list for this notification, then add this to tmp dictionary
			if(Item.Value.Count > 0)
				tmpListeners.Add (Item.Key, Item.Value);
		}

		//Replace listeners ojet with new , optimized dictionary
		Listeners = tmpListeners;
	}

	//Called when a new level is loaded;remove redundant entries from dictionary if leaft from last scene
	void OnLevelWasLoaded()
	{
		//clear Redundancies
		RemoveRedundancies ();
	}
	
}
