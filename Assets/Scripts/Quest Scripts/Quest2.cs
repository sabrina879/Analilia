using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest2 : MonoBehaviour
{
    public GameObject fairy;
    private QuestGiver tracker;
    public GameObject portal;
    public GameObject flower;

    // Start is called before the first frame update
    void Start()
    {
        tracker = GameObject.Find("Hide n Seek!").GetComponent<QuestGiver>();

        if (tracker.quest.progress == 3)
        {
            fairy.SetActive(true);
        }
    }

    public void Checker()
    {
        string[] fairies = new string[3] { "Elora", "Haela", "Daella" };

        if(fairy.name.ToString() == "Lilith" && tracker.quest.progress == 0)
        {
            GameObject.Find("Pink Flower").tag = "Interactable";
        }
        if (tracker.quest.progress < 3 && fairy.name.ToString() == fairies[tracker.quest.progress])
        {
            tracker.quest.progress++;
            if (tracker.quest.progress == 1)
            {
                tracker.descText.text = "Find Haela.";
                flower.tag = "Interactable";
            }
            if (tracker.quest.progress == 2)
            {
                tracker.descText.text = "Find Daella.";
                flower.tag = "Interactable";
            }
            if (fairy.name.ToString() == fairies[2])
            {
                tracker.quest.progress = 3;
                tracker.CompleteQuest();
                tracker.descText.text = "Quest Complete! Return To Lilith.";
                GameObject.Find("Orange Flower").tag = "Untagged";
                GameObject.Find("Pink Flower").tag = "Untagged";
                gameObject.tag = "Untagged";
            }
        }
        if(tracker.quest.progress == 3 && fairy.name.ToString() == "Lilith")
        {
            GameObject.Find("Quest2Icon").GetComponent<Image>().enabled = false;
            GameObject.Find("Trial2Icon").GetComponent<Image>().enabled = true;

            tracker.descText.text = "Enter the portal.";
            tracker.titleText.text = "Begin Trial 2";

            GameObject.Find("Right Door - Quest 2").tag = "Untagged";
            GameObject.Find("Right Door").tag = "Untagged";

//            GameObject.Find("QuestSignifer - Lilith").SetActive(false);

            portal.SetActive(true);
        }
    }
}
