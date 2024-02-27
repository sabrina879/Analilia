using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        GameObject.Find("StartSpawn").GetComponent<SpawnPoint>().enabled = true;
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
