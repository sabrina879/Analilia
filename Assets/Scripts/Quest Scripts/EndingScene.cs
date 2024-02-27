using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class EndingScene : MonoBehaviour
{

    private QuestGiver tracker;

    void Start()
    {

        tracker = GameObject.Find("EndingOffice").GetComponent<QuestGiver>();
        tracker.titleText.text = "Back At the Office";
        tracker.descText.text = "You've learned so much in the labyrinth! Ask Hans for a promotion.";

        if (tracker.quest.isActive == false && tracker.quest.isComplete == false)
        {
            
            tracker.ShowActiveQuest();
            tracker.AcceptQuest();
            tracker.quest.goal = 1;
            
        }
    }

    public void TalkToHans()
    {
        tracker.titleText.text = "Confront Frank";
        tracker.descText.text = "Find Frank and talk to him.";
    }
}

