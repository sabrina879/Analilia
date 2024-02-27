using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest3 : MonoBehaviour
{
    private QuestGiver tracker;
    public GameObject goblin;
    public GameObject BellestaQuest;
    public GameObject DoreahQuest;
    public GameObject HaemirQuest;
    public GameObject GoguQuest;
    public GameObject BrobekQuest;
    public GameObject MyrinnQuest;
    public GameObject AngorQuest;
    public GameObject DoorQuest;

    public GameObject CutsceneCharacterss;

    // 0 - Myrinn, 1 - Angor
    //public GameObject[] questSignifier;

    // Start is called before the first frame update
    void Start()
    {
        //if (GameObject.Find("CutsceneCharacters") != null)
        //{

        
        CutsceneCharacterss = GameObject.Find("CutsceneCharacters");
        //CutsceneCharacterss.SetActive(false);

       // }

        tracker = GameObject.Find("Representative").GetComponent<QuestGiver>();
        GameObject.Find("NoActiveQuestIcon").GetComponent<Image>().enabled = true;
        GameObject.Find("Trial2Icon").GetComponent<Image>().enabled = false; 
        tracker.titleText.text = "No Active Quest";
        tracker.descText.text = "Maybe there is someone around here who can help me...";      
    }

    public void Checker()
    {
        if (tracker.quest.isActive == false && tracker.quest.isComplete == false)
        {
            // Player has interacted with Myrinn and quest can begin
            tracker.ShowActiveQuest();
            tracker.AcceptQuest();
            GameObject.Find("Quest3Icon").GetComponent<Image>().enabled = true;
            GameObject.Find("NoActiveQuestIcon").GetComponent<Image>().enabled = false;
            GameObject.Find("Myrinn").tag = "Untagged";
            GameObject.Find("Bellesta").tag = "Interactable";
            GameObject.Find("Doreah").tag = "Interactable";
            GameObject.Find("Haemir").tag = "Interactable";
            GameObject.Find("Gogu").tag = "Interactable";
            GameObject.Find("Brobek").tag = "Interactable";
            MyrinnQuest.SetActive(false);
            Debug.Log("Turn off Myrinn questSignifier");
            BellestaQuest.SetActive(true);
            HaemirQuest.SetActive(true);
            GoguQuest.SetActive(true);
            DoreahQuest.SetActive(true);
            BrobekQuest.SetActive(true);
        }
        // player can interact with goblins in any order
        if (tracker.quest.progress < 5 && goblin.name.ToString() != "Myrinn")
        {
            // if Player is interacting with NPC who is NOT Myrinn (Quest Lead)
            tracker.quest.progress++;
            tracker.ShowActiveQuest();
            goblin.tag = "Untagged";

            // deactivate visual quest signifier child object attached to goblin parent object
            if(goblin.name.ToString() == "Bellesta")
                BellestaQuest.SetActive(false);
            else if(goblin.name.ToString() == "Doreah")
                DoreahQuest.SetActive(false);
            else if(goblin.name.ToString() == "Haemir")
                HaemirQuest.SetActive(false);
            else if(goblin.name.ToString() == "Gogu")
                GoguQuest.SetActive(false);
            else if(goblin.name.ToString() == "Brobek")
                BrobekQuest.SetActive(false);

            // if this is the 5th goblin the player has interacted with: change quest objective
            if(tracker.quest.progress == 5)
            {
            GameObject.Find("Angor").tag = "Interactable";
            AngorQuest.SetActive(true);
            Debug.Log("Turn ON Angor questSignifier");
            tracker.descText.text = "Deliver Evidence to Angor.";                
            }

        }

        // since Angor cant be interacted with until this point, just need one if
        if (goblin.name.ToString() == "Angor")
        {
            tracker.descText.text = "Quest Complete! Talk to Myrinn.";
            GameObject.Find("Myrinn").tag = "Interactable";
            MyrinnQuest.SetActive(true);
            AngorQuest.SetActive(false);
            GameObject.Find("Angor").tag = "Untagged";
        }

        // if you talk to Myrinn and the quest is complete
        if (tracker.quest.progress == 5 && goblin.name.ToString() == "Myrinn" && tracker.quest.isComplete == false)
        {
            tracker.CompleteQuest();
            GameObject.Find("Angor").tag = "Untagged";
            MyrinnQuest.SetActive(false);
            AngorQuest.SetActive(false);
            tracker.titleText.text = "No Active Quest";
            tracker.descText.text = "Find Hungus.";
            GameObject.Find("Ogre Hallway").tag = "Interactable";
            GameObject.Find("Quest3Icon").GetComponent<Image>().enabled = false;
            GameObject.Find("NoActiveQuestIcon").GetComponent<Image>().enabled = true;
            DoorQuest.SetActive(true);
        }
    }

}
