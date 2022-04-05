using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	private CharacterAnimation playerAnimation;

	private Rigidbody myBody;

	public float walkSpeed = 2f;
	public float zSpeed = 1.5f;

	private float rotationY = -90f;
	private float rotationSpeed = 15f;
	

	void Awake() 
	{
		myBody = GetComponent<Rigidbody>();
		playerAnimation = GetComponentInChildren<CharacterAnimation>();
	}

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		RotatePlayer();
		//print("Value: " + Input.GetAxisRaw(Axis.HORIZONTAL_AXIS));
		AnimatePlayerWalk();
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

	void AnimatePlayerWalk()
	{
		if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) != 0 || Input.GetAxisRaw(Axis.VERTICAL_AXIS) != 0){
			playerAnimation.Walk(true);
		}
		else{
			playerAnimation.Walk(false);
		}
	}
}
