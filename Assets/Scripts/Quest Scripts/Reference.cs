using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reference : MonoBehaviour
{
    private QuestGiver tracker;
    
    //TRIAL 1
    public void HideNSeek()
    {
        tracker = GameObject.Find("Hide n Seek!").GetComponent<QuestGiver>();
        if(tracker.quest.isActive == false || tracker.quest.progress == 0)
        {
            GameObject.Find("Hide n Seek!").GetComponent<QuestGiver>().ShowActiveQuest();
            GameObject.Find("Hide n Seek!").GetComponent<QuestGiver>().AcceptQuest();
            GameObject.Find("Quest2Icon").GetComponent<Image>().enabled = true;
            GameObject.Find("NoActiveQuestIcon").GetComponent<Image>().enabled = false;          
        }


    }

    public void HideNSeekComplete()
    {        
        GameObject.Find("Hide n Seek!").GetComponent<QuestGiver>().CompleteQuest();
        GameObject.Find("Hide n Seek!").GetComponent<QuestGiver>().hidePanel();
    }

    public void RuneMeThis()
    {
        tracker = GameObject.Find("Rune Me This").GetComponent<QuestGiver>();
        if (tracker.quest.isComplete == false)
        {
            tracker.ShowActiveQuest();
            tracker.AcceptQuest();

        }

    }

    public void RuneMeThisComplete()
    {
        GameObject.Find("Rune Me This").GetComponent<QuestGiver>().CompleteQuest();
        GameObject.Find("Rune Me This").GetComponent<QuestGiver>().hidePanel();
    }


    // TRIAL 2
    public void Representative()
    {
        GameObject.Find("Representative").GetComponent<QuestGiver>().ShowActiveQuest();
        GameObject.Find("Representative").GetComponent<QuestGiver>().AcceptQuest();
    }

    public void RepresentativeComplete()
    {
        GameObject.Find("Representative").GetComponent<QuestGiver>().CompleteQuest();
        GameObject.Find("Representative").GetComponent<QuestGiver>().hidePanel();
    }

    public void EyeLostIt()
    {
        tracker = GameObject.Find("Eye Lost It!").GetComponent<QuestGiver>();
        if (tracker.quest.isActive == false)
        {
            GameObject.Find("Eye Lost It!").GetComponent<QuestGiver>().ShowActiveQuest();
            GameObject.Find("Eye Lost It!").GetComponent<QuestGiver>().AcceptQuest();
        }


    }

    // TRIAL 3

    public void TomeOfParallels()
    {
        GameObject.Find("Tome of Parallels").GetComponent<QuestGiver>().ShowActiveQuest();
        GameObject.Find("Tome of Parallels").GetComponent<QuestGiver>().AcceptQuest();
    }
}
