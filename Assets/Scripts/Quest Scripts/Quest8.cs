using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest8 : MonoBehaviour
{
    private GameObject Analilia;
    private GameObject Isadora;
    public GameObject BlueLights;
    public GameObject RedLights;
    public GameObject GreenLights;
    private QuestGiver tracker;
    public GameObject BridgeWall;
    public GameObject AnaliliaPrefab;

    GameObject AnaliliaPlayerPrefab;


    private PlayerManager player;

    public GameObject questPanel;

    // Get Animator from Analilia Character Prefab Gameobject
    Animator anim;



    // Start is called before the first frame update
    void Start()
    {

        tracker = GameObject.Find("Cave of Confidence").GetComponent<QuestGiver>();

        tracker.titleText.text = "No quest active";
        tracker.descText.text = "...Maybe there is someone around here who can help me.";
        GameObject.Find("NoActiveQuestIcon").GetComponent<Image>().enabled = true;
        GameObject.Find("Quest7Icon").GetComponent<Image>().enabled = false;

        Isadora = GameObject.Find("Isadora");

        Analilia = GameObject.Find("Analilia");

        player = Analilia.GetComponent<PlayerManager>();

        // change waypoint NPC to player.childobject
        anim = AnaliliaPrefab.GetComponent<Animator>();
        AnaliliaPrefab.SetActive(false);
    }

    public void Quest8Panel()
    {
        GameObject.Find("NoActiveQuestIcon").GetComponent<Image>().enabled = false;
        GameObject.Find("Quest8Icon").GetComponent<Image>().enabled = true;
        tracker.titleText.text = "Cave of Confidence";
        tracker.descText.text = "Choose the Confident Statement";

    }

    /*public void setPlayerPrefabInvisible()
    {
      //AnaliliaPlayerPrefab.SetActive(false);
      AnaliliaPrefab.SetActive(true);

    }*/


    // Update is called once per frame
    void Update()
    {
    }

    private GameObject getChildWithName(GameObject obj, string name)
    {
        Transform trans = obj.transform;
        Transform childTrans = trans.Find(name);
        if (childTrans != null)
        {
            return childTrans.gameObject;
        }
        else
        {
            return null;
        }
    }

    public void CameraSwitch()
    {
        GameObject.Find("Questions Scene").GetComponent<Camera>().enabled = true;
        Isadora.transform.localScale = new Vector3(0, 0, 0);
        //Analilia.transform.position = GameObject.Find("Start").transform.position;
       // Analilia.transform.rotation = GameObject.Find("Start").transform.rotation;

        AnaliliaPrefab.transform.position = GameObject.Find("Start").transform.position;
        AnaliliaPrefab.transform.rotation = GameObject.Find("Start").transform.rotation;

        // get Analilia Prefab child of Analilia game object and make false
        AnaliliaPlayerPrefab = getChildWithName(Analilia, "Analilia");
        AnaliliaPlayerPrefab.SetActive(false);

        AnaliliaPrefab.SetActive(true);


        GameObject.Find("QuestSignifier - Isadora").SetActive(false);
    }

    public void CameraToPlayer()
    {
        GameObject.Find("Questions Scene").GetComponent<Camera>().enabled = false;

        AnaliliaPlayerPrefab.SetActive(true);

        BlueLights.SetActive(true);
        RedLights.SetActive(false);
        GreenLights.SetActive(false);
        tracker.CompleteQuest();

        Analilia.transform.position = GameObject.Find("Finish").transform.position;

        tracker.titleText.text = "No Active Quest";
        tracker.descText.text = "Quest Complete! Proceed through the door.";

    }

    // will change the animation from anxious to idle to walking
    public void analiliaWalk()
    {
        // get Talilia's Animation component and update animation
        anim.SetBool("isWalking", true);
        anim.SetBool("isIdle", false);

    }
    public void analiliaIdle()
    {
        // get Talilia's Animation component and update animation
        anim.SetBool("isWalking", false);
        anim.SetBool("isIdle", true);
    }

    public void setBridgeWallActive()
    {
        BridgeWall.SetActive(true);
    }

    public IEnumerator MovetoOneOne() // CORRECT
    {
        BlueLights.SetActive(false);
        GreenLights.SetActive(true);

        player.IncrementLives();
        Debug.Log(player.lives);

        while (Vector3.Distance(GameObject.Find("Waypoint 1-1").transform.position, AnaliliaPrefab.transform.position) >= 0.1f)
        {

           // Analilia.transform.position = Vector3.MoveTowards(Analilia.transform.position, GameObject.Find("Waypoint 1-1").transform.position, Time.deltaTime * 5);
            AnaliliaPrefab.transform.position = Vector3.MoveTowards(AnaliliaPrefab.transform.position, GameObject.Find("Waypoint 1-1").transform.position, Time.deltaTime * 5);

            yield return  new WaitForEndOfFrame();
        }

    }
    public IEnumerator MovetoOneTwo()
    {
        BlueLights.SetActive(false);
        RedLights.SetActive(true);
        while (Vector3.Distance(GameObject.Find("Waypoint 1-2").transform.position, AnaliliaPrefab.transform.position) >= 0.1f)
        {

            //Analilia.transform.position = Vector3.MoveTowards(Analilia.transform.position, GameObject.Find("Waypoint 1-2").transform.position, Time.deltaTime * 5);
            AnaliliaPrefab.transform.position = Vector3.MoveTowards(AnaliliaPrefab.transform.position, GameObject.Find("Waypoint 1-2").transform.position, Time.deltaTime * 5);

            yield return new WaitForEndOfFrame();
        }
    }
    public IEnumerator MovetoOneThree()
    {
        BlueLights.SetActive(false);
        RedLights.SetActive(true);
        while (Vector3.Distance(GameObject.Find("Waypoint 1-3").transform.position, AnaliliaPrefab.transform.position) >= 0.1f)
        {

            //Analilia.transform.position = Vector3.MoveTowards(Analilia.transform.position, GameObject.Find("Waypoint 1-3").transform.position, Time.deltaTime * 5);
            AnaliliaPrefab.transform.position = Vector3.MoveTowards(AnaliliaPrefab.transform.position, GameObject.Find("Waypoint 1-3").transform.position, Time.deltaTime * 5);

            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator MovetoTwoOne()
    {
        RedLights.SetActive(true);
        GreenLights.SetActive(false);


        while (Vector3.Distance(GameObject.Find("Waypoint 2-1").transform.position, AnaliliaPrefab.transform.position) >= 0.1f)
        {

           // Analilia.transform.position = Vector3.MoveTowards(Analilia.transform.position, GameObject.Find("Waypoint 2-1").transform.position, Time.deltaTime * 5);
            AnaliliaPrefab.transform.position = Vector3.MoveTowards(AnaliliaPrefab.transform.position, GameObject.Find("Waypoint 2-1").transform.position, Time.deltaTime * 5);

            yield return new WaitForEndOfFrame();
        }
    }
    public IEnumerator MovetoTwoTwo() //CORRECT
    {
        RedLights.SetActive(false);
        GreenLights.SetActive(true);

        player.IncrementLives();
        Debug.Log(player.lives);

        while (Vector3.Distance(GameObject.Find("Waypoint 2-2").transform.position, AnaliliaPrefab.transform.position) >= 0.1f)
        {

            //Analilia.transform.position = Vector3.MoveTowards(Analilia.transform.position, GameObject.Find("Waypoint 2-2").transform.position, Time.deltaTime * 5);
            AnaliliaPrefab.transform.position = Vector3.MoveTowards(AnaliliaPrefab.transform.position, GameObject.Find("Waypoint 2-2").transform.position, Time.deltaTime * 5);

            yield return new WaitForEndOfFrame();
        }
    }
    public IEnumerator MovetoTwoThree()
    {
        RedLights.SetActive(true);
        GreenLights.SetActive(false);

        while (Vector3.Distance(GameObject.Find("Waypoint 2-3").transform.position, AnaliliaPrefab.transform.position) >= 0.1f)
        {

          //  Analilia.transform.position = Vector3.MoveTowards(Analilia.transform.position, GameObject.Find("Waypoint 2-3").transform.position, Time.deltaTime * 5);
            AnaliliaPrefab.transform.position = Vector3.MoveTowards(AnaliliaPrefab.transform.position, GameObject.Find("Waypoint 2-3").transform.position, Time.deltaTime * 5);

            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator MovetoThreeOne()
    {
        RedLights.SetActive(true);
        GreenLights.SetActive(false);

        while (Vector3.Distance(GameObject.Find("Waypoint 3-1").transform.position, AnaliliaPrefab.transform.position) >= 0.1f)
        {
           // Analilia.transform.position = Vector3.MoveTowards(Analilia.transform.position, GameObject.Find("Waypoint 3-1").transform.position, Time.deltaTime * 5);
            AnaliliaPrefab.transform.position = Vector3.MoveTowards(AnaliliaPrefab.transform.position, GameObject.Find("Waypoint 3-1").transform.position, Time.deltaTime * 5);

            yield return new WaitForEndOfFrame();
        }

    }
    public IEnumerator MovetoThreeTwo() //CORRECT
    {
        RedLights.SetActive(false);
        GreenLights.SetActive(true);

        player.IncrementLives();
        Debug.Log(player.lives);

        while (Vector3.Distance(GameObject.Find("Waypoint 3-2").transform.position, AnaliliaPrefab.transform.position) >= 0.1f)
        {
            //Analilia.transform.position = Vector3.MoveTowards(Analilia.transform.position, GameObject.Find("Waypoint 3-2").transform.position, Time.deltaTime * 5);
            AnaliliaPrefab.transform.position = Vector3.MoveTowards(AnaliliaPrefab.transform.position, GameObject.Find("Waypoint 3-2").transform.position, Time.deltaTime * 5);

            yield return new WaitForEndOfFrame();
        }
    }
    public IEnumerator MovetoThreeThree()
    {
        RedLights.SetActive(true);
        GreenLights.SetActive(false);

        while (Vector3.Distance(GameObject.Find("Waypoint 3-3").transform.position, AnaliliaPrefab.transform.position) >= 0.1f)
        {
           // Analilia.transform.position = Vector3.MoveTowards(Analilia.transform.position, GameObject.Find("Waypoint 3-3").transform.position, Time.deltaTime * 5);
            AnaliliaPrefab.transform.position = Vector3.MoveTowards(AnaliliaPrefab.transform.position, GameObject.Find("Waypoint 3-3").transform.position, Time.deltaTime * 5);

            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator MovetoFourOne()
    {
        RedLights.SetActive(true);
        GreenLights.SetActive(false);

        while (Vector3.Distance(GameObject.Find("Waypoint 4-1").transform.position, AnaliliaPrefab.transform.position) >= 0.1f)
        {
           // Analilia.transform.position = Vector3.MoveTowards(Analilia.transform.position, GameObject.Find("Waypoint 4-1").transform.position, Time.deltaTime * 5);
            AnaliliaPrefab.transform.position = Vector3.MoveTowards(AnaliliaPrefab.transform.position, GameObject.Find("Waypoint 4-1").transform.position, Time.deltaTime * 5);

            yield return new WaitForEndOfFrame();
        }

    }
    public IEnumerator MovetoFourTwo()
    {
        RedLights.SetActive(true);
        GreenLights.SetActive(false);

        while (Vector3.Distance(GameObject.Find("Waypoint 4-2").transform.position, AnaliliaPrefab.transform.position) >= 0.1f)
        {
           // Analilia.transform.position = Vector3.MoveTowards(Analilia.transform.position, GameObject.Find("Waypoint 4-2").transform.position, Time.deltaTime * 5);
            AnaliliaPrefab.transform.position = Vector3.MoveTowards(AnaliliaPrefab.transform.position, GameObject.Find("Waypoint 4-2").transform.position, Time.deltaTime * 5);

            yield return new WaitForEndOfFrame();
        }
    }
    public IEnumerator MovetoFourThree() // CORRECT
    {
        RedLights.SetActive(false);
        GreenLights.SetActive(true);

        player.IncrementLives();
        Debug.Log(player.lives);

        while (Vector3.Distance(GameObject.Find("Waypoint 4-3").transform.position, AnaliliaPrefab.transform.position) >= 0.1f)
        {
            //Analilia.transform.position = Vector3.MoveTowards(Analilia.transform.position, GameObject.Find("Waypoint 4-3").transform.position, Time.deltaTime * 5);
            AnaliliaPrefab.transform.position = Vector3.MoveTowards(AnaliliaPrefab.transform.position, GameObject.Find("Waypoint 4-3").transform.position, Time.deltaTime * 5);

            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator MovetoFiveOne()
    {
        RedLights.SetActive(true);
        GreenLights.SetActive(false);

        while (Vector3.Distance(GameObject.Find("Waypoint 5-1").transform.position, AnaliliaPrefab.transform.position) >= 0.1f)
        {
            //Analilia.transform.position = Vector3.MoveTowards(Analilia.transform.position, GameObject.Find("Waypoint 5-1").transform.position, Time.deltaTime * 5);
            AnaliliaPrefab.transform.position = Vector3.MoveTowards(AnaliliaPrefab.transform.position, GameObject.Find("Waypoint 5-1").transform.position, Time.deltaTime * 5);

            yield return new WaitForEndOfFrame();
        }

    }
    public IEnumerator MovetoFiveTwo() //CORRECT
    {
        RedLights.SetActive(false);
        GreenLights.SetActive(true);

        player.IncrementLives();
        Debug.Log(player.lives);

        while (Vector3.Distance(GameObject.Find("Waypoint 5-2").transform.position, AnaliliaPrefab.transform.position) >= 0.1f)
        {
           // Analilia.transform.position = Vector3.MoveTowards(Analilia.transform.position, GameObject.Find("Waypoint 5-2").transform.position, Time.deltaTime * 5);
            AnaliliaPrefab.transform.position = Vector3.MoveTowards(AnaliliaPrefab.transform.position, GameObject.Find("Waypoint 5-2").transform.position, Time.deltaTime * 5);

            yield return new WaitForEndOfFrame();
        }
    }
    public IEnumerator MovetoFiveThree()
    {
        RedLights.SetActive(true);
        GreenLights.SetActive(false);

        while (Vector3.Distance(GameObject.Find("Waypoint 5-3").transform.position, AnaliliaPrefab.transform.position) >= 0.1f)
        {
            //Analilia.transform.position = Vector3.MoveTowards(Analilia.transform.position, GameObject.Find("Waypoint 5-3").transform.position, Time.deltaTime * 5);
            AnaliliaPrefab.transform.position = Vector3.MoveTowards(AnaliliaPrefab.transform.position, GameObject.Find("Waypoint 5-3").transform.position, Time.deltaTime * 5);

            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator MovetoFinish()
    {

        while (Vector3.Distance(GameObject.Find("Finish").transform.position, AnaliliaPrefab.transform.position) >= 0.1f)
        {
            //Analilia.transform.position = Vector3.MoveTowards(Analilia.transform.position, GameObject.Find("Finish").transform.position, Time.deltaTime * 5);
            AnaliliaPrefab.transform.position = Vector3.MoveTowards(AnaliliaPrefab.transform.position, GameObject.Find("Finish").transform.position, Time.deltaTime * 5);
            AnaliliaPrefab.SetActive(false);


yield return new WaitForEndOfFrame();
        }
    }

    public void removeQuestPanel()
    {
        questPanel.SetActive(false);
        Cursor.visible = true;

        Cursor.lockState = CursorLockMode.Confined;
    }


}
