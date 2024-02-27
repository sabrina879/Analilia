using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public ParticleSystem[] Fx;
    public GameObject[] walls;
    public GameObject wallPointY;
    public GameObject wallScene;

    // Start is called before the first frame update
    void Start()
    {
        foreach (ParticleSystem fx in Fx)
        {
            fx.Stop();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator MoveWalls()
    {


        while (Vector3.Distance(walls[0].transform.position, new Vector3(walls[0].transform.position.x, wallPointY.transform.position.y, walls[0].transform.position.z)) >= 0.000001f)
        {
            walls[0].transform.position = Vector3.MoveTowards(walls[0].transform.position, new Vector3(walls[0].transform.position.x, wallPointY.transform.position.y, walls[0].transform.position.z), Time.deltaTime * 2.5f);

            if (Vector3.Distance(walls[0].transform.position, new Vector3(walls[0].transform.position.x, wallPointY.transform.position.y, walls[0].transform.position.z)) <= 2.2f)
            {

                Fx[2].Stop();
            }

            yield return new WaitForEndOfFrame();
        }




    }

    public void leaverUntagged()
    {

        gameObject.tag = "Untagged";
    }

    public void changeToWallScene()
    {
        wallScene.GetComponent<Camera>().enabled = true;
        foreach (ParticleSystem fx in Fx)
        {
            fx.Play();
        }
        wallScene.GetComponent<AudioSource>().Play();
    }
    public void changeToPlayerScene()
    {
        wallScene.GetComponent<Camera>().enabled = false;
        
    }
}
