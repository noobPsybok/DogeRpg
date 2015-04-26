using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	CircleCollider2D circleCollider;
	bool input_fire;
	bool previousInput;
	bool attacking;					// Bool to control attack cycle
	[Range(0.0f, 20.0f)]
	public float attackCooldown;				// Slider to control attack timing
	float implementedTimer;

	// Use this for initialization
	void Start () {

		circleCollider = GetComponent<CircleCollider2D>();	// Set up the circular attack radius
		circleCollider.isTrigger = true;
		implementedTimer = 0;
		
	}

	void OnTriggerStay2D (Collider2D col)
	{
		// Logic to keep enemies from blowing up
		input_fire = Input.GetButton ("Fire1");

		if (input_fire && !previousInput && implementedTimer <= 0)
		{
			implementedTimer = attackCooldown;
			
			Debug.Log("Collider hit something!");
		}
		else if (implementedTimer > 0)
			implementedTimer -= Time.deltaTime;

		previousInput = Input.GetMouseButton(0);
	}
}
