using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest7 : MonoBehaviour
{
    private QuestGiver tracker;
    public GameObject[] CandleLights;
    public GameObject aprendeSpell;
    private bool helpedTalilia = false;
    private bool guidanceFromSelene = false;

    // Start is called before the first frame update
    void Start()
    {
        helpedTalilia = false;
        tracker = GameObject.Find("TombTroubles").GetComponent<QuestGiver>();

        GameObject.Find("Quest7Icon").GetComponent<Image>().enabled = true;
        GameObject.Find("Quest6Icon").GetComponent<Image>().enabled = false;

        if (tracker.quest.isActive == false && tracker.quest.isComplete == false)
        {
            // Player has interacted with Myrinn and quest can begin
            tracker.ShowActiveQuest();
            tracker.AcceptQuest();
            tracker.quest.goal = 3;
            tracker.descText.text = "Talk to the young girl";
        }
        CandleLights[0].SetActive(false);
        CandleLights[1].SetActive(false);
        CandleLights[2].SetActive(false);

        aprendeSpell.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool spokeTaliliaState()
    {
        return helpedTalilia;
    }
    // the following are called by the dialogue tree of interactables
    public void spokeToTalilia()
    {
        GameObject.Find("Collider1").SetActive(false);
        helpedTalilia = true;
        Debug.Log("Finished Talking to Talilia");
        tracker.descText.text = "Go with Talilia";
        GameObject.Find("Talilia").tag = "Untagged";
        // turn ON first set of candlelights
        CandleLights[0].SetActive(true);
        GameObject.Find("Conversation1").tag = "Interactable";
    }
    public void spokeToSelene()
    {
        Debug.Log("Finished Talking to Selene");
        guidanceFromSelene = true;
        tracker.descText.text = "Follow Talilia as she uses her magic to turn on last candle set";
        // move to first waypoint stage
        // make this stage uninteractable
        GameObject.Find("Conversation1").tag = "Untagged";
        // turn ON second set of candlelights
        CandleLights[1].SetActive(true);
        GameObject.Find("Conversation1").tag = "Untagged";
        GameObject.Find("TaliliasMagic").tag = "Interactable";
        GameObject.Find("Collider2").SetActive(false);

    }

    public void magicSkills()
    {
        // trigger magic incantation effect to go off
        tracker.quest.progress++;
        tracker.descText.text = "Lit up all confidence candles!!";
        // make this stage uninteractable
        GameObject.Find("TaliliasMagic").tag = "Untagged";
        // turn on final candle set
        CandleLights[2].SetActive(true);
        aprendeSpell.SetActive(true);
        GameObject.Find("TaliliasMagic").tag = "Untagged";
        GameObject.Find("Tierno").tag = "Interactable";
        GameObject.Find("Collider3").SetActive(false);


    }

    public void completedCandleSets()
    {
        tracker.descText.text = "Together with Talilia, talk to Tierno";
    }

    public void spokeWithTierno()
    {
        tracker.descText.text = "Go through the door behind Tierno to move on to next quest!";
        GameObject.Find("Tierno").tag = "Untagged";
        GameObject.Find("Exit Door").tag = "Interactable";


    }

    public void goodbyeTalilia()
    {
        tracker.descText.text = "Say your goodbyes to Talilia.";
        tracker.CompleteQuest();
        //GameObject.Find("Talilia").tag = "Untagged";

    }

}
