using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    
	public float gravity;
	public float jumpHeight;
	private bool grounded = false;
	public Rigidbody rb;
	private bool canDoubleJump = true;

	// Update is called once per frame
	void Update()
    {
		Vector3 velocity = rb.velocity;
		if (grounded)
		{   // Jump
			//canDoubleJump = false; not work

			if (Input.GetButtonDown("Jump"))
			{
				rb.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
				canDoubleJump = true;
			}
		}
		//Double jump hopefully if not triple randomly
		else
		{
			if (Input.GetButtonDown("Jump") && canDoubleJump)
			{
				rb.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
				canDoubleJump = false;
			}
		}


	}
	void OnCollisionStay()
	{
		grounded = true;
	}

    private void OnCollisionExit(Collision collision)
    {
		grounded = false;
    }
    float CalculateJumpVerticalSpeed()
	{
		// From the jump height and gravity we deduce the upwards speed 
		// for the character to reach at the apex.
		return Mathf.Sqrt(2 * jumpHeight * gravity);
	}

}
