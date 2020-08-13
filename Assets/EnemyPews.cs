using UnityEngine;
using System.Collections;

public class EnemyPews : MonoBehaviour
{
    Transform target;
    Transform origin;

    private GameObject enemy;

    RaycastHit hit;

    private float player_hitPoints;

    public float gunDamage = 25f;                                            // Set the number of hitpoints that this gun will take away from shot objects with a health script
    public float fireRate = 0.25f;                                        // Number in seconds which controls how often the player can fire
    public float weaponRange = 30f;                                        // Distance in Unity units over which the player can fire
    public float hitForce = 100f;                                        // Amount of force which will be added to objects with a rigidbody shot by the player
    public Transform gunEnd;                                            // Holds a reference to the gun end object, marking the muzzle location of the gun

    // Holds a reference to the first person camera
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);    // WaitForSeconds object used by our ShotEffect coroutine, determines time laser line will remain visible
    private AudioSource gunAudio;                                        // Reference to the audio source which will play our shooting sound effect
    private LineRenderer laserLine;                                        // Reference to the LineRenderer component which will display our laserline
    private float nextFire;                                                // Float to store the time the player will be allowed to fire again, after firing


    void Start()
    {
        // Get and store a reference to our LineRenderer component
        laserLine = GetComponent<LineRenderer>();


        target = PlayerManager.instance.player.transform;

        player_hitPoints = PlayerManager.instance.player_hitPoints;

    }

    void Update()
    {

        Debug.DrawRay(transform.position, transform.forward * 30f, Color.magenta);

        // Set the start position for our visual effect for our laser to the position of gunEnd
        laserLine.SetPosition(0, gunEnd.position);

        // Check if our raycast has hit anything
        if (Physics.Raycast(transform.position, transform.forward , out hit, 30f))
        {


            // If there was a health script attached

            player_hitPoints -= gunDamage;


            // Check if the object we hit has a rigidbody attached
            if (hit.rigidbody != null)
            {
                // Add force to the rigidbody we hit, in the direction from which it was hit
                hit.rigidbody.AddForce(-hit.normal * hitForce);
            }

        }
    }
}
