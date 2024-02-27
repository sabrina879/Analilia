using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour {

    public GameObject[] waypoints;
    //public GameObject player;
    int current = 0;
    float rotSpeed;
    public float speed;
    float WPradius = 1;

	void Update () {
		if(Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
        {
            // specific order of waypoints for NPC to visit
            // this should only increase when Analilia player presses E
            current++;
            //current = Random.Range(0,waypoints.Length);
            if (current >= waypoints.Length)
            {
                current = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);

    }

    /*void OnTriggerEnter(Collider n)
    {
        if (n.gameObject == player)
        {
            player.transform.parent = transform;
        }
    }
    void OnTriggerExit(Collider n)
    {
        if (n.gameObject == player)
        {
            player.transform.parent = null;
        }
    }*/
}
