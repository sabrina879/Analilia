using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class MessagePane : MonoBehaviour
{
    public bool isInRange;
    public KeyCode key;

    public GameObject InteractGUI;

    // Start is called before the first frame update
    void Start()
    {
        InteractGUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (isInRange)
        {
            if (Input.GetKeyDown(key))
            {
                isInRange = false;

                InteractGUI.SetActive(false);

            }
        }
        InteractGUI.SetActive(isInRange);

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            isInRange = true;
            InteractGUI.SetActive(isInRange);


        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            isInRange = false;
            InteractGUI.SetActive(isInRange);


        }


    }



}
