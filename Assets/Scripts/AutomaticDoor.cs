using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// update door
public class AutomaticDoor : MonoBehaviour
{
    public GameObject movingDoor;
    //public GameObject doorSensor;

    public float maximumOpening = 10f;
    public float maximumClosing = 0f;

    public float movementSpeed = 5f;

    // instead of this, we are comparing isInRange
    public bool openDoor = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void slideDoor()
    {
        // open since player pressed E
        if (openDoor == false)
        {
            // door is opening
            while(movingDoor.transform.position.x < maximumOpening){
                movingDoor.transform.Translate(movementSpeed * Time.deltaTime, 0f, 0f);
            }
            openDoor = true;
        }

    }
    public void closeDoor()
    {
      if (openDoor == true)
      {
          // close door
          while(movingDoor.transform.position.x > maximumClosing){
              movingDoor.transform.Translate(-movementSpeed * Time.deltaTime, 0f, 0f);
          }
          openDoor = false;
      }
    }
}
