using UnityEngine;
using System.Collections;

public class ColliderManager : MonoBehaviour 
{
	public Transform thisPos;
	public Vector3 cachePos;
	// Use this for initialization
	void Start () 
	{
		thisPos = gameObject.transform;
		cachePos = thisPos.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log(other.name + this.gameObject);
	}
}
