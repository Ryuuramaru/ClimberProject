﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class Movementtry2 : MonoBehaviour
{

	public float speed;
	public float rawspeed;
	public float gravity;
	public float maxVelocityChange = 10.0f;
	public Rigidbody rigidbody;
	
	

	void Awake()
	{
		rigidbody.freezeRotation = true;
		rigidbody.useGravity = false;
	}

	void FixedUpdate()
	{
		
			if (Input.GetButton("Run")) speed = rawspeed * 1.75f; //Normal or Run speed function
			else speed = rawspeed;

			// Calculate how fast we should be moving
			Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			targetVelocity = transform.TransformDirection(targetVelocity);
			targetVelocity *= speed;

			// Apply a force that attempts to reach our target velocity
			Vector3 velocity = rigidbody.velocity;
			Vector3 velocityChange = (targetVelocity - velocity);
			velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
			velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
			velocityChange.y = 0;
			rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);

		

		    // We apply gravity manually for more tuning control
			rigidbody.AddForce(new Vector3(0, -gravity * rigidbody.mass, 0));

		
	}




}