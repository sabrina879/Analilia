using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition7To8 : MonoBehaviour
{
    private QuestGiver tracker;

    // Start is called before the first frame update
    void Start()
    {
      tracker = GameObject.Find("Transition River").GetComponent<QuestGiver>();

      if (tracker.quest.isActive == false && tracker.quest.isComplete == false)
      {
          // Player has interacted with Myrinn and quest can begin
          tracker.ShowActiveQuest();
          tracker.AcceptQuest();
          tracker.quest.goal = 1;
          //tracker.titleText.text = "River of ";
          tracker.descText.text = "Say your goodbyes to Talilia before moving on";
      }
    }

    public void UpdateQuestPanel()
    {
        tracker.descText.text = "Make your way to the Cave entrance.";
    }

    public void completedQuest()
    {
        tracker.CompleteQuest();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
