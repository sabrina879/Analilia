using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMover : MonoBehaviour
{
    public GameObject SpawnPosition;

    public void moveSpawnPoint() {
        GameObject.Find("StartSpawn").transform.position = SpawnPosition.transform.position;
    }

    public void disableSpawnScript(){
        GameObject.Find("StartSpawn").GetComponent<SpawnPoint>().enabled = false;
    }

    public void enableSpawnScript(){
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
