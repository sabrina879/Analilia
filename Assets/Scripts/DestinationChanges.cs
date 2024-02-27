using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationChanges : MonoBehaviour
{
    public int xPos;
    public int zPos;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            xPos = Random.Range(10, 30);
            zPos = Random.Range(11, 30);
            this.gameObject.transform.position = new Vector3(xPos, 1.5f, zPos);
        }
    }
    



}
