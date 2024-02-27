using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.DialogueTrees;
using Random = System.Random;
using System;
using UnityEngine.UI;

public class Quest9Old : MonoBehaviour
{ /*
    public GameObject EvilWitch;
    public DialogueTreeController dialogue;
    public GameObject ObjectUI;
    public GameObject LivesUI;
    public GameObject LifeAnimation;
    public Camera AnaliliaCamera;
    public Camera Scene1Camera;
    public Camera Scene2Camera;
    public Camera Scene3Camera;
    public Camera Scene4Camera;
    public Camera Scene5Camera;
    public Camera Scene6Camera;
    public Camera Scene7Camera;
    public Camera Scene8Camera;
    public static int[] hasShown = new int[8];
    public static int hasShownCounter = 0;
    public static int[] correctScenes = new int[8];
    public static int[] incorrectScenes = new int[8];
    public static int correctCounter = 0;
    public static int incorrectCounter = 0;
    public static int lives = 5;

    // Start is called before the first frame update
    // Starts the dialogue immediately upon entering the scene
    void Start()
    {
    }

    // Goes back to the Main CombatScene Camera
    public void AnaliliaCameraEnable()
    {
        AnaliliaCamera.GetComponent<Camera>().enabled = true;
        LivesUI.SetActive(true);
    }

    public void EnableObjectUI()
    {
        LivesUI.SetActive(false);
        ObjectUI.SetActive(true);
    }

    public void RemoveLife()
    {
        LifeAnimation.SetActive(true);
        switch(lives)
        {
            case 5:
                GameObject.Find("Life 5").GetComponent<Image>().color = new Color32(255, 0, 11, 75);
                lives--;
                break;

            case 4:
                GameObject.Find("Life 4").GetComponent<Image>().color = new Color32(255, 0, 11, 75);
                lives--;
                break;

            case 3:
                GameObject.Find("Life 3").GetComponent<Image>().color = new Color32(255, 0, 11, 75);
                lives--;
                break;

            case 2:
                GameObject.Find("Life 2").GetComponent<Image>().color = new Color32(255, 0, 11, 75);
                lives--;
                break;

            case 1:
                GameObject.Find("Life 1").GetComponent<Image>().color = new Color32(255, 0, 11, 75);
                lives--;
                break;
        }
    }

    public void RemoveLifeWitch()
    {
        switch(correctCounter)
        {
            case 1:
                GameObject.Find("WitchLife 1").GetComponent<Image>().color = new Color32(146, 0, 255, 75);
                break;

            case 2:
                GameObject.Find("WitchLife 2").GetComponent<Image>().color = new Color32(146, 0, 255, 75);
                break; 

            case 3:
                GameObject.Find("WitchLife 3").GetComponent<Image>().color = new Color32(146, 0, 255, 75);
                break;      

            case 4:
                GameObject.Find("WitchLife 4").GetComponent<Image>().color = new Color32(146, 0, 255, 75);
                break;   

            case 5:
                GameObject.Find("WitchLife 5").GetComponent<Image>().color = new Color32(146, 0, 255, 75);
                break;      
        }
    }

    public bool checkWin()
    {
        if(correctCounter == 5)
            return true;
        else
            return false;
    }

    public bool checkLose()
    {
        if(lives == 0)
            return true;
        else
            return false;
    }

    public bool checkTie()
    {
        if(lives == 1 && correctCounter == 4 && hasShownCounter == 8)
            return true;
        else
            return false;
    }

    // Switches the Camera to Scene 1: The Office Scene with Frank
    public void FrankOfficeScene()
    {
        Scene1Camera.GetComponent<Camera>().enabled = true;
        hasShown[hasShownCounter] = 1;
        hasShownCounter++;
        Debug.Log(hasShownCounter);
        
    }
    public void FrankOfficeSceneDisable()
    {
        Scene1Camera.GetComponent<Camera>().enabled = false;
    }

    // Switches the Camera to Scene 2: Office Scene 2
    public void OfficeScene2()
    {
        Scene2Camera.GetComponent<Camera>().enabled = true;
        hasShown[hasShownCounter] = 2;
        hasShownCounter++;
        Debug.Log(hasShownCounter);
    }
    public void OfficeScene2Disabled()
    {
        Scene2Camera.GetComponent<Camera>().enabled = false;
    }

    // Switches Camera to Scene 3
    public void PlayScene3()
    {
        Scene3Camera.GetComponent<Camera>().enabled = true;
        hasShown[hasShownCounter] = 3;
        hasShownCounter++;
        Debug.Log(hasShownCounter);
    }
    public void DisableScene3()
    {
        Scene3Camera.GetComponent<Camera>().enabled = false;
    }

    // Switches Camera to Scene 4
    public void PlayScene4()
    {
        Scene4Camera.GetComponent<Camera>().enabled = true;
        hasShown[hasShownCounter] = 4;
        hasShownCounter++;
        Debug.Log(hasShownCounter);
    }
    public void DisableScene4()
    {
        Scene4Camera.GetComponent<Camera>().enabled = false;
    }  

    // Switches Camera to Scene 5
    public void PlayScene5()
    {
        Scene5Camera.GetComponent<Camera>().enabled = true;
        hasShown[hasShownCounter] = 5;
        hasShownCounter++;
        Debug.Log(hasShownCounter);
    }
    public void DisableScene5()
    {
        Scene5Camera.GetComponent<Camera>().enabled = false;
    } 

    // Switches Camera to Scene 6
    public void PlayScene6()
    {
        Scene6Camera.GetComponent<Camera>().enabled = true;
        hasShown[hasShownCounter] = 6;
        hasShownCounter++;
        Debug.Log(hasShownCounter);
    }
    public void DisableScene6()
    {
        Scene6Camera.GetComponent<Camera>().enabled = false;
    } 

    // Switches Camera to Scene 7
    public void PlayScene7()
    {
        Scene7Camera.GetComponent<Camera>().enabled = true;
        hasShown[hasShownCounter] = 7;
        hasShownCounter++;
        Debug.Log(hasShownCounter);
    }
    public void DisableScene7()
    {
        Scene7Camera.GetComponent<Camera>().enabled = false;
    }

    // Switches Camera to Scene 8
    public void PlayScene8()
    {
        Scene8Camera.GetComponent<Camera>().enabled = true;
        hasShown[hasShownCounter] = 8;
        hasShownCounter++;
        Debug.Log(hasShownCounter);
    }
    public void DisableScene8()
    {
        Scene8Camera.GetComponent<Camera>().enabled = false;
    }

    // The loop for finding a scene number that has not already been used.
    private int SceneNumLoop()
    {
        Random randomScene = new Random();
        var temp = randomScene.Next(2,9);

        bool check = Array.Exists(hasShown, element => element == temp);

        if(check == true)
            return SceneNumLoop();
        else
            return temp;
    }

    // Calls the scene number loop and adds it to the hasShown array
    // and returns the number associated to the dialogue tree
    public int ChooseScene()
    {
        var temp = SceneNumLoop();

        hasShown[hasShownCounter] = temp;

        return temp;
    }

    // Puts the given scene number into the "Correct" array
    public void putCorrectScenes(int sceneNum)
    {
        correctScenes[correctCounter] = sceneNum;
        correctCounter++;
    }

    //Puts the given scene number into the "Incorrect" array
    public void putIncorrectScenes(int sceneNum)
    {
        incorrectScenes[incorrectCounter] = sceneNum;
        incorrectCounter++;
    } */

}