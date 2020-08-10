using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    
	public float gravity;
	public bool canJump = true;
	public float jumpHeight;
	public bool grounded = false;
	public Rigidbody rigidbody;
	public bool canDoubleJump = true;

	// Update is called once per frame
	void Update()
    {
		Vector3 velocity = rigidbody.velocity;
		if (grounded)
		{   // Jump
			canDoubleJump = false;

			if (Input.GetButtonDown("Jump"))
			{
				rigidbody.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
				grounded = false;
				canDoubleJump = true;
			}
		}
		//Double jump hopefully
		else
		{
			if (Input.GetButtonDown("Jump") && canDoubleJump)
			{
				rigidbody.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
				canDoubleJump = false;
			}
		}


	}
	void OnCollisionStay()
	{
		grounded = true;
	}
	float CalculateJumpVerticalSpeed()
	{
		// From the jump height and gravity we deduce the upwards speed 
		// for the character to reach at the apex.
		return Mathf.Sqrt(2 * jumpHeight * gravity);
	}

}
