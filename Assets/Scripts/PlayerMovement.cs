using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class PlayerMovement : MonoBehaviour
{

	private float speed;
	public float rawspeed;
	public float gravity;
	public float maxVelocityChange = 10.0f;
	public Rigidbody rb;
	//private bool grounded = false;



	void Awake()
	{
		rb.freezeRotation = true;
		rb.useGravity = false;
	}

	/*
	void OnCollisionStay()
	{
		grounded = true;
	}

	void OnCollisionExit()
    {
		grounded = false;
    }
	*/
    void FixedUpdate()
	{

			if (Input.GetButton("Run")) speed = rawspeed * 1.75f; //Normal or Run speed function
			else speed = rawspeed;

			// Calculate how fast we should be moving
			Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			targetVelocity = transform.TransformDirection(targetVelocity);
			targetVelocity *= speed;

			// Apply a force that attempts to reach our target velocity
			Vector3 velocity = rb.velocity;
			Vector3 velocityChange = (targetVelocity - velocity);
			velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
			velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
			velocityChange.y = 0;
			rb.AddForce(velocityChange, ForceMode.VelocityChange);
		
		    // We apply gravity manually for more tuning control
			rb.AddForce(new Vector3(0, -gravity * rb.mass, 0));
	}
}