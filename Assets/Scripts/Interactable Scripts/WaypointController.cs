using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointController : MonoBehaviour
{
    public GameObject[] waypoints;
    // need to add a Character Controller so NPC does NOT look like its floating
    public GameObject waypointNPC;
    // current waypoint NPC is positioned at/to go to
    int current = 0;
    // stores whether Talilia is actively moving or not
    bool moveNPC = false;
    public float speed;
    float WPradius = 0.1f;

    // I'm going to have to get Animator from waypointNPC Gameobject
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = waypointNPC.GetComponent<Animator>();
    }
    // will change the animation from anxious to idle to walking
    public void taliliaWalk()
    {
        // get Talilia's Animation component and update animation
        anim.SetBool("isWalking", true);
        anim.SetBool("isIdle", false);

    }
    public void taliliaIdle()
    {
        // get Talilia's Animation component and update animation
        anim.SetBool("isWalking", false);
        anim.SetBool("isIdle", true);
    }

    public void updateWaypoint0()
    {
        // change to rotateNPC = true
        moveNPC = true;
    }
    // Update is called once per frame
    void Update()
    {
        // have an if (rotateNPC == true)
          // completely rotate direction of 
        // check if we can move the NPC forward by confirming dialogue is finished
        if (moveNPC == true)
        {
            // NEED TO IMPLEMENT: make sure NPC completely rotates before moving forward

            // determine direction to rotate towards
            Vector3 targetDirection = waypoints[current].transform.position - waypointNPC.transform.position;
            // rotate forward vector towards target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(waypointNPC.transform.forward, targetDirection, Time.deltaTime * speed, 0.0f);
            // Calculate a rotation a step closer to the target and applies rotation to this object
            waypointNPC.transform.rotation = Quaternion.LookRotation(newDirection);

            // updates Talilias position to next waypoint
            waypointNPC.transform.position = Vector3.MoveTowards(waypointNPC.transform.position, waypoints[current].transform.position, Time.deltaTime * speed);

            // check if distance between desired waypoint position and NPC position is less than the desired radius
            if(Vector3.Distance(waypoints[current].transform.position, waypointNPC.transform.position) < WPradius)
            {
                // if NPC is has reached waypoint, increase current
                current++;
                if (current >= waypoints.Length)
                {
                    // Talilia stops moving
                    moveNPC = false;
                    taliliaIdle();
                }
            }
        }
    }
}
