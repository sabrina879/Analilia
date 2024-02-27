using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MemoryScene : MonoBehaviour
{


    public void book3Interactable()
    {
        GameObject.Find("Book3").tag = "Interactable";
    
    }

    public void enableGalliard()
    {
        GameObject.Find("Galliard").GetComponent<Collider>().enabled = true;
    }

}
