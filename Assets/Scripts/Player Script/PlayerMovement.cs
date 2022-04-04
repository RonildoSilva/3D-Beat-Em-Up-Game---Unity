using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	//private PlayerAnimation playerAnimation;

	private Rigidbody myBody;

	public float walkSpeed = 2f;
	public float zSpeed = 1.5f;

	private float rotationY = -90f;
	private float rotationSpeed = 15f;
	

	void Awake() 
	{
		myBody = GetComponent<Rigidbody>();
		//playerAnimation = GetComponentInChildren<PlayerAnimation>();
	}

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		RotatePlayer();
		print("Value: " + Input.GetAxisRaw(Axis.HORIZONTAL_AXIS));
	}

	void FixedUpdate()
	{
		DetectMovement();
	}

	void DetectMovement()
	{
		myBody.velocity = new Vector3(
			Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) * (-walkSpeed),
			myBody.velocity.y,
			Input.GetAxisRaw(Axis.VERTICAL_AXIS) * (-zSpeed)
		);
	}

	void RotatePlayer()
	{
		if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) > 0)
		{
			transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
		}
		else if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) < 0)
		{
			transform.rotation = Quaternion.Euler(0f, Mathf.Abs(rotationY), 0f);
		}

	}
}
