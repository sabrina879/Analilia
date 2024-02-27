using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trial1Doors : MonoBehaviour
{
    private QuestGiver tracker;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider collision)
    {
        tracker = GameObject.Find("Rune Me This").GetComponent<QuestGiver>();
        if(tracker.quest.isComplete == true)
        {
            GameObject.Find("Right Door").tag = "Interactable";
            GameObject.Find("Right Door - Quest 2").tag = "Untagged";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
