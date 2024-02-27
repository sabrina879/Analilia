using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.DialogueTrees;
using Random = System.Random;
using System;
using UnityEngine.UI;

// This script enables and disables the Cameras for each scene
// And enables/disables the Object Select UI
public class Quest9 : MonoBehaviour
{
    // Cameras
    public Camera Scene1Camera;
    public Camera Scene2Camera;
    public Camera Scene3Camera;
    public Camera Scene4Camera;
    public Camera Scene5Camera;
    public Camera Scene6Camera;
    public Camera Scene7Camera;
    public Camera Scene8Camera;

    // UI Objects
    public GameObject Objects;

    // Camera Enables and Disables:
    // ================================================

    // Goes back to the Main CombatScene Camera
    public void AnaliliaCameraEnable()
    {
        GameObject.Find("Main Camera 1").GetComponent<Camera>().enabled = true;
    }

    // Scene 1
    public void Scene1CameraEnable()
    {
        Scene1Camera.GetComponent<Camera>().enabled = true;
        
    }
    public void Scene1CameraDisable()
    {
        Scene1Camera.GetComponent<Camera>().enabled = false;
    }

    // Scene 2
    public void Scene2CameraEnable()
    {
        Scene2Camera.GetComponent<Camera>().enabled = true;
    }
    public void Scene2CameraDisable()
    {
        Scene2Camera.GetComponent<Camera>().enabled = false;
    }

    // Scene 3
    public void Scene3CameraEnable()
    {
        Scene3Camera.GetComponent<Camera>().enabled = true;
    }
    public void Scene3CameraDisable()
    {
        Scene3Camera.GetComponent<Camera>().enabled = false;
    } 

    // Scene 4
    public void Scene4CameraEnable()
    {
        Scene4Camera.GetComponent<Camera>().enabled = true;
    }
    public void Scene4CameraDisable()
    {
        Scene4Camera.GetComponent<Camera>().enabled = false;
    }

    // Scene 5
    public void Scene5CameraEnable()
    {
        Scene5Camera.GetComponent<Camera>().enabled = true;
    }
    public void Scene5CameraDisable()
    {
        Scene5Camera.GetComponent<Camera>().enabled = false;
    }

    // Scene 6
    public void Scene6CameraEnable()
    {
        Scene6Camera.GetComponent<Camera>().enabled = true;
    }
    public void Scene6CameraDisable()
    {
        Scene6Camera.GetComponent<Camera>().enabled = false;
    } 
    
    // Scene 7
    public void Scene7CameraEnable()
    {
        Scene7Camera.GetComponent<Camera>().enabled = true;
    }
    public void Scene7CameraDisable()
    {
        Scene7Camera.GetComponent<Camera>().enabled = false;
    } 

    // Scene 8
    public void Scene8CameraEnable()
    {
        Scene8Camera.GetComponent<Camera>().enabled = true;
    }
    public void Scene8CameraDisable()
    {
        Scene8Camera.GetComponent<Camera>().enabled = false;
    } 

    // UI Enables and Disables:
    // ================================================

    public void enableObjectUI()
    {
        Objects.SetActive(true);
    }




}

 