using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest1 : MonoBehaviour
{

    private QuestGiver tracker;
    private QuestGiver tracker2;

    public GameObject RuneColor;

    public AudioSource myFx;
    public AudioClip successFx;
    public GameObject correctRuneParticle;

    public GameObject BelstramIdentifer;
    public GameObject DoorIdentifier;

    // Start is called before the first frame update
    void Start()
    {
        tracker = GameObject.Find("Rune Me This").GetComponent<QuestGiver>();
        tracker2 = GameObject.Find("Hide n Seek!").GetComponent<QuestGiver>(); // to check if next quest is not active

        if (tracker.quest.isComplete)
        {
            if (!tracker2.quest.isActive)
            {
                tracker.titleText.text = "No Active Quest";
                tracker.descText.text = "Talk to the Sorceress.";
            }
        }
        else
        {
            GameObject.Find("NoActiveQuestIcon").GetComponent<Image>().enabled = true;
            tracker.titleText.text = "No Active Quest";
            tracker.descText.text = "Maybe there is someone around here who can help me...";
        }
    }

    public void Checker()
    {

        GameObject[] temp;
        string[] runes = new string[5] { "Orange Rune", "Red Rune", "White Rune", "Blue Rune", "Green Rune" };

        if (tracker.quest.progress == 0)
        {
            GameObject.Find("Quest1Icon").GetComponent<Image>().enabled = true;
            GameObject.Find("NoActiveQuestIcon").GetComponent<Image>().enabled = false;
            GameObject.Find("Orange Rune").tag = "Interactable";
            GameObject.Find("Red Rune").tag = "Interactable";
            GameObject.Find("White Rune").tag = "Interactable";
            GameObject.Find("Blue Rune").tag = "Interactable";
            GameObject.Find("Green Rune").tag = "Interactable";
        }

        if (tracker.quest.progress < 5 && RuneColor.name.ToString() == runes[tracker.quest.progress] && RuneColor.name.ToString() != "Belstram")
        {
            tracker.quest.progress++;
            myFx.PlayOneShot(successFx);
            correctRuneParticle.SetActive(true);
            tracker.ShowActiveQuest();

            BelstramIdentifer.SetActive(true);



            gameObject.tag = "Untagged";

            for (int i = tracker.quest.progress; i < 5; i++)
            {
                GameObject.Find(runes[i]).tag = "Interactable Hold";
            }


            if (RuneColor.name.ToString() == runes[4])
            {

                tracker.quest.progress = 5;
                tracker.descText.text = "Quest Complete! Talk to Belstram.";

            }

        }


        else if (RuneColor.name.ToString() == "Belstram")
        {
            if (tracker.quest.progress >= 0 && tracker.quest.progress != 5)
            {
                BelstramIdentifer.SetActive(false);

                temp = GameObject.FindGameObjectsWithTag("Interactable Hold");

                foreach (GameObject rune in temp)
                {
                    rune.tag = "Interactable";
                }
            }

        }

        if (tracker.quest.progress == 5 && RuneColor.name.ToString() == "Belstram" && !tracker2.quest.isActive)// checking if next quest is not active. (so quest Icon does not appear)
        {
            tracker.CompleteQuest();
            tracker.titleText.text = "No Active Quest";
            tracker.descText.text = "Talk to the Sorceress.";
            GameObject.Find("Right Door").tag = "Interactable";
            DoorIdentifier.SetActive(true);
            GameObject.Find("Quest1Icon").GetComponent<Image>().enabled = false;
            GameObject.Find("NoActiveQuestIcon").GetComponent<Image>().enabled = true;
            BelstramIdentifer.SetActive(false);
            GameObject.Find("Belstram").tag = "Untagged";
        }
    }
}
