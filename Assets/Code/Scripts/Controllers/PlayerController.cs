using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	Animator anim;
	public NotificationsManager Notification;

	public Vector3 playerPos;	

	public float input_x;
	public float input_y;
	public bool isWaking;

	void Awake ()
	{
		Notification = GameObject.Find("GameManager").GetComponent<NotificationsManager>();
		anim = GetComponent<Animator>();
	}
	// Use this for initialization
	void Start () 
	{

	}

	void Update ()
	{
		playerPos = gameObject.transform.position;

		input_x = Input.GetAxisRaw("Horizontal");
		input_y = Input.GetAxisRaw("Vertical");
		isWaking = (Mathf.Abs(input_x) + Mathf.Abs(input_y)) > 0;

		anim.SetBool("IsWalking",isWaking);
		if (isWaking)
		{
			anim.SetFloat("Input_x",input_x);
			anim.SetFloat("Input_y",input_y);

		transform.position += new Vector3(input_x,input_y,0.0f).normalized * Time.deltaTime;
		}

	}
}