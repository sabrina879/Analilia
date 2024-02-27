using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public KeyCode key;
    public UnityEvent interactAction;
    private QuestGiver tracker;
    private QuestGiver questRef;

    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(key))
            {
                isInRange = false;
                interactAction.Invoke();
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameObject.tag == "Interactable")
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameObject.tag == "Interactable")
        {
            isInRange = false;
        }
    }
}
