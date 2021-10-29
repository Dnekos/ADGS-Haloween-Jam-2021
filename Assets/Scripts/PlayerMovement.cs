using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
	// maxSpeed in units/sec
	[SerializeField] private float maxSpeed = 2f;
	
	// acceleration in units/sec^2
	[SerializeField] private float acceleration = 5f;
	
	// should the player immediately stop when keys are released?
	[SerializeField] private bool stopImmediately = true;

	[SerializeField] private bool enableBoost = true;
	[SerializeField] private float maxBoostSpeed = 10f;

	[SerializeField] private float minSpeed = .05f;

	private Vector2 inputDir;
	private Rigidbody2D rigidBody;

	private bool isBoosting = false;

	// Start is called before the first frame update
	void Start()
	{
		 rigidBody = GetComponent<Rigidbody2D>();
		 
	}

	public void OnMove(InputAction.CallbackContext context)
	{
		inputDir = context.ReadValue<Vector2>();
	}

	public void OnBoost(InputAction.CallbackContext context)
	{
		if(context.started)
			isBoosting = true;
		else if (context.canceled)
		{
			isBoosting = false;
		}
	}

	private void FixedUpdate()
	{
		float currentMaxSpeed = (isBoosting&&enableBoost) ? (maxBoostSpeed) : (maxSpeed);
		
        if (inputDir == Vector2.zero && stopImmediately)
        {
	       rigidBody.velocity = Vector2.zero;
        }

        if (inputDir != Vector2.zero && rigidBody.velocity.magnitude < currentMaxSpeed)
        {
	        rigidBody.AddForce(inputDir.normalized*acceleration*rigidBody.mass);
        }

        else if (inputDir != Vector2.zero && rigidBody.velocity.magnitude > currentMaxSpeed)
	        rigidBody.velocity = inputDir*currentMaxSpeed;

        if (rigidBody.velocity.magnitude < minSpeed)
        {
	        rigidBody.velocity=Vector2.zero;
        }
	}

	// Update is called once per frame
	void Update()
	{
	
	}
}
