using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeQuest : MonoBehaviour
{
    private QuestGiver tracker;
    private bool askedForPromotion;
    public GameObject interactableObject;
    public GameObject exitDoor;

    // Start is called before the first frame update
    void Start()
    {
        askedForPromotion = false;
        tracker = GameObject.Find("OfficeIntro").GetComponent<QuestGiver>();
        if (tracker.quest.isActive == false && tracker.quest.isComplete == false)
        {
            // Player has interacted with Myrinn and quest can begin
            tracker.ShowActiveQuest();
            tracker.AcceptQuest();
            tracker.quest.goal = 2;
           // tracker.titleText.text = "Quest Started: Office Tutorial";
           // tracker.descText.text = "Find your boss, Hans' office to ask for a promotion.";
        } 
        exitDoor.SetActive(false);
    }

    /*public void Checker()
    {
        if (interactableObject.name.ToString() == "Door1")
        {
            Debug.Log("Interacted with door 1");
            tracker.quest.progress++;
            tracker.descText.text = "Find your boss and ask for a promotion! Doorways opened:" + " (" + tracker.quest.progress.ToString() + "/" + tracker.quest.goal.ToString() + ")";
        }
        else if (interactableObject.name.ToString() == "BossDoor")
        {
            Debug.Log("Interacted with door 2");
            tracker.quest.progress++;
            tracker.descText.text = "Find your boss and ask for a promotion! Doorways opened:" + " (" + tracker.quest.progress.ToString() + "/" + tracker.quest.goal.ToString() + ")";
        }
    }*/

    public void spokeToBoss()
    {
        askedForPromotion = true;
        Debug.Log("Finished Asking Boss for a Promotion");
        tracker.quest.progress++;
      //  tracker.descText.text = "Quest Unsuccessful. Go back to your office.";
        // turn on exit door interactable
        exitDoor.SetActive(true);
    }

}
