using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public PlayerManager player;
    public GameObject questPanel;
    public Text titleText;
    public Text descText;
    public Text rewardText;


    public void ShowActiveQuest()
    {

        if (quest.isComplete == true)
        {
            titleText.text = "";
            descText.text = "";
            quest.isActive = false;
        }
        else
            questPanel.SetActive(true);

        titleText.text = quest.title;

        if (quest.goal == 1 || quest.progress > quest.goal)
        {
            descText.text = quest.description;
        }
        else
        {
            descText.text = quest.description + " (" + quest.progress.ToString() + "/" + quest.goal.ToString() + ")";
        }

        if (quest.reward != 0)
        {
            rewardText.text = "Reward: " + quest.reward.ToString();
        }

    }

    public void incrementProgress()
    {
        quest.progress++;
        descText.text = quest.description + " (" + quest.progress.ToString() + "/" + quest.goal.ToString() + ")";

        if (quest.progress == quest.goal)
        {
            CompleteQuest();
        }
    }

    public void AcceptQuest()
    {
        if (quest.isComplete == true)
        {
            titleText.text = "";
            descText.text = "";
            quest.isActive = false;
        }
        else
            quest.isActive = true;
    }

    public void CompleteQuest()
    {
        quest.isActive = false;
        quest.isComplete = true;
    }

    public void hidePanel()
    {
        questPanel.SetActive(false);
    }

}


