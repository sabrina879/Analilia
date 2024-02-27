using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ScreenRes : MonoBehaviour
{
    void Update()
    {

    }

    public void SetQuality()
    {
        setResolution();
    }
    
    void setResolution()
    {
        // Gets the name of which button you pressed
        string index = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        switch(index)
        {
            case "1152x648 Button":
                Screen.SetResolution(1152,648,true);
                break;
            case "1280x720 Button":
                Screen.SetResolution(1280,720,true);
                break;
            case "1360x764 Button":
                Screen.SetResolution(1360,764,true);
                break;
            case "1920x1080 Button":
                Screen.SetResolution(1920,1080,true);
                break;
        }
    }
}
