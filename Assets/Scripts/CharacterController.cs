using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public float speed = 3.0f;
    private float realspeed;
    
    private Vector3 jump;
    private Vector3 gravity;
    Vector3 x, z;

    public float jumpHeight = 15f;

    private bool isGrounded;


    Rigidbody rb;


    // Use this for initialization
    void Start()
    {
        // turn off the cursor
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();
        jump = new Vector3 (0.0f, 1.0f, 0.0f);
        gravity = new Vector3 (0.0f, -9.8f, 0.0f);
    }

    void OnCollisionEnter(Collision theCollision)
    {
            isGrounded = true;
    }

    void OnCollisionExit(Collision theCollision)
    {
            isGrounded = false;
    }

    

    void Update()
    {

        x = transform.right * Input.GetAxisRaw("Horizontal");
        z = transform.forward * Input.GetAxisRaw("Vertical");
        //if(isGrounded == false) rb.AddForce (gravity * 25, ForceMode.Acceleration); //Simulated gravity

        if (Input.GetButton("Run")) realspeed = speed * 1.75f; //Normal or Run speed function
        else realspeed = speed;


        /*
         translation = Input.GetAxis("Vertical") * realspeed * Time.deltaTime; //Move Function
        straffe = Input.GetAxis("Horizontal") * realspeed * Time.deltaTime;
        transform.Translate(straffe, 0, translation); 
                
                        *****DEPRECATED*****
        */ 

        //rb.AddForce(transform.forward * realspeed * Input.GetAxis ("Vertical") * Time.deltaTime * 2); //new movement ws 
        //rb.AddForce(transform.right * realspeed * Input.GetAxis ("Horizontal") * Time.deltaTime * 2); //ad


        if (Input.GetButtonDown("Jump") && isGrounded) //jump function
        {
            rb.AddForce (jump * jumpHeight, ForceMode.Impulse);
        }

        if (Input.GetKeyUp("escape"))
        {
            // turn on/off the cursor
            /// WIP
            if (Cursor.lockState == CursorLockMode.None) Cursor.lockState = CursorLockMode.Locked;
            else if (Cursor.lockState == CursorLockMode.Locked) Cursor.lockState = CursorLockMode.None;
        }
        
    }
}
