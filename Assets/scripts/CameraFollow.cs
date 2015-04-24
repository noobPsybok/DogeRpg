using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public Transform target; // Target of what to follow
	Camera myCam;
	
	// Use this for initialization
	void Start () {
		
		myCam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		
		// Keep a consistent size view ratio, no matter the screen size
		myCam.orthographicSize = Screen.height / 100f / 4f;
		
		if(target)
		{
			transform.position = Vector3.Lerp(transform.position, target.position, 0.2f) + new Vector3(0, 0, -10f);
		}
		
	}
}