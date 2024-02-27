using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayTrialAnimation : MonoBehaviour
{
    //public Animation TrialText;
    public bool hasPlayedTrial1;
    public bool hasPlayedTrial2;
    public bool hasPlayedTrial3;
    public bool hasPlayedTrial4;
    public bool hasPlayedTrial5;

    void Awake()
    {
        hasPlayedTrial1 = false;
        hasPlayedTrial2 = false;
        hasPlayedTrial3 = false;
        hasPlayedTrial4 = false;
        hasPlayedTrial5 = false;

        GameObject.Find("Trial1").GetComponent<Text>().enabled = false;
        GameObject.Find("Trial1Outline").GetComponent<Image>().enabled = false;
        GameObject.Find("Trial1Start").GetComponent<Animation>().Stop("NewTrial");

        GameObject.Find("Trial2").GetComponent<Text>().enabled = false;
        GameObject.Find("Trial2Outline").GetComponent<Image>().enabled = false;
        GameObject.Find("Trial2Start").GetComponent<Animation>().Stop("NewTrial2");

        GameObject.Find("Trial3").GetComponent<Text>().enabled = false;
        GameObject.Find("Trial3Outline").GetComponent<Image>().enabled = false;
        GameObject.Find("Trial3Start").GetComponent<Animation>().Stop("NewTrial3");

        GameObject.Find("Trial4").GetComponent<Text>().enabled = false;
        GameObject.Find("Trial4Outline").GetComponent<Image>().enabled = false;
        GameObject.Find("Trial4Start").GetComponent<Animation>().Stop("NewTrial4");

        GameObject.Find("Trial5").GetComponent<Text>().enabled = false;
        GameObject.Find("Trial5Outline").GetComponent<Image>().enabled = false;
        GameObject.Find("Trial5Start").GetComponent<Animation>().Stop("NewTrial5");


    }

    void Update()
    { 
       Scene currentScene = SceneManager.GetActiveScene();

       string sceneName = currentScene.name;

       Time.timeScale = 1;

       if(sceneName == "Quest 1 & 2 - Rune Me This" && hasPlayedTrial1 == false)
       {
            hasPlayedTrial1 = true;
            GameObject.Find("Trial1").GetComponent<Text>().enabled = true;
            GameObject.Find("Trial1Outline").GetComponent<Image>().enabled = true;
            GameObject.Find("Trial1Start").GetComponent<Animation>().Play("NewTrial");
       }

       if(sceneName == "Quest 3 - Representative" && hasPlayedTrial2 == false)
       {
            hasPlayedTrial2 = true;
            GameObject.Find("Trial2").GetComponent<Text>().enabled = true;
            GameObject.Find("Trial2Outline").GetComponent<Image>().enabled = true;
            GameObject.Find("Trial2Start").GetComponent<Animation>().Play("NewTrial2");
            GameObject.Find("GateSignifier").GetComponent<ParticleSystem>().Stop(); // TRIAL 3 GATE SIGNIFIER GATE
        }

        if(sceneName == "Quest 5 - Tome of Parallels" && hasPlayedTrial3 == false)
        {
            hasPlayedTrial3 = true;
            GameObject.Find("Trial3").GetComponent<Text>().enabled = true;
            GameObject.Find("Trial3Outline").GetComponent<Image>().enabled = true;
            GameObject.Find("Trial3Start").GetComponent<Animation>().Play("NewTrial3");
        }


        if (sceneName == "Quest 7 - Tome Troubles" && hasPlayedTrial4 == false)
        {
            hasPlayedTrial4 = true;
            GameObject.Find("Trial4").GetComponent<Text>().enabled = true;
            GameObject.Find("Trial4Outline").GetComponent<Image>().enabled = true;
            GameObject.Find("Trial4Start").GetComponent<Animation>().Play("NewTrial4");
        } 

        if(sceneName == "Quest 9 - Self Reflection" && hasPlayedTrial5 == false)
        {
            hasPlayedTrial5 = true;
            GameObject.Find("Trial5").GetComponent<Text>().enabled = true;
            GameObject.Find("Trial5Outline").GetComponent<Image>().enabled = true;
            GameObject.Find("Trial5Start").GetComponent<Animation>().Play("NewTrial5");
        }



    }
}
