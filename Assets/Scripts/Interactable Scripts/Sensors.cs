using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensors : MonoBehaviour
{
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            string sensorName = string.Copy(gameObject.name);
            Debug.Log("Player ENTERED: " + sensorName);
            if (sensorName == "Sensor2")
            {
              Debug.Log("Sending message to Door: " + sensorName);
              //door.SendMessage("updateSensor2", true);
              door.SendMessage("closeDoor");
              //door.SendMessage("updateSensor1", false);
            }
            else if (sensorName == "Sensor1")
            {
              Debug.Log("Sending message to Door: " + sensorName);
              door.SendMessage("closeDoor");
            }
        }
    }
}
