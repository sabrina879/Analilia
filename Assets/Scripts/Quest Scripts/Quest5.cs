using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest5 : MonoBehaviour
{
    private QuestGiver tracker;
    public GameObject nameCheck;
    public GameObject DoorIdentifier;
    public GameObject book3held;
    public GameObject lever1;
    private bool hasTalkedToPhrankus;

    // Start is called before the first frame update
    void Start()
    {
        hasTalkedToPhrankus = false;
        tracker = GameObject.Find("Tome of Parallels").GetComponent<QuestGiver>();
        GameObject.Find("QuestSignifier - Phrankus").GetComponent<ParticleSystem>().Stop();
        tracker.descText.text = "Maybe there's someone around here who can help me.";
        tracker.titleText.text = "No Active Quest";
        if (lever1 != null)
        {
            lever1.GetComponent<ParticleSystem>().Stop();
        }
       // GameObject.Find("NoActiveQuestIcon").GetComponent<Image>().enabled = true;
    }

    public void Checker()
    {
        if (nameCheck.name.ToString() == "Bonna" && tracker.quest.isComplete == false)
        {
            GameObject.Find("Lever1").tag = "Interactable";
            GameObject.Find("QuestSignifier - Bonna").GetComponent<ParticleSystem>().Stop();
            GameObject.Find("QuestSignifier - Phrankus").GetComponent<ParticleSystem>().Play();
            GameObject.Find("Phrankus").tag = "Interactable";
            GameObject.Find("NoActiveQuestIcon").GetComponent<Image>().enabled = false;
            GameObject.Find("Quest5Icon").GetComponent<Image>().enabled = true;
        }

        if (nameCheck.name.ToString() == "Phrankus" && tracker.quest.progress == 0 && hasTalkedToPhrankus == false)
        {
            hasTalkedToPhrankus = true;
            GameObject.Find("QuestSignifier - Galliard").GetComponent<ParticleSystem>().Play();
            lever1.GetComponent<ParticleSystem>().Play();
            tracker.descText.text = "Find Potions Books" + " (" + tracker.quest.progress.ToString() + "/" + tracker.quest.goal.ToString() + ")";
            GameObject.Find("Bonna").tag = "Untagged";
            book3held.SetActive(true);
            GameObject.Find("Galliard").GetComponent<Animator>().SetBool("hasTalkedToPhrankus", true);
            GameObject.Find("Galliard").transform.position = new Vector3(39.9589996f, 0.538999975f, -19.9820004f);
            GameObject.Find("Galliard").transform.rotation = new Quaternion(0, 0.353475034f, 0f, -0.935443997f);



            GameObject.Find("QuestSignifier - Phrankus").GetComponent<ParticleSystem>().Stop();
        }

        if (nameCheck.name.ToString() == "Book1" || nameCheck.name.ToString() == "Book2" || nameCheck.name.ToString() == "Book3")
        {
            nameCheck.SetActive(false);
            if (nameCheck.name.ToString() == "Book1" )
            {
                tracker.quest.progress++;
                tracker.descText.text = "Find Potions Books" + " (" + tracker.quest.progress.ToString() + "/" + tracker.quest.goal.ToString() + ")";
            }
            if (nameCheck.name.ToString() == "Book2")
            {
                tracker.quest.progress++;
                tracker.descText.text = "Find Potions Books" + " (" + tracker.quest.progress.ToString() + "/" + tracker.quest.goal.ToString() + ")";
            }
            if (nameCheck.name.ToString() == "Book3")
            {
                tracker.quest.progress++;
                tracker.descText.text = "Find Potions Books" + " (" + tracker.quest.progress.ToString() + "/" + tracker.quest.goal.ToString() + ")";
            }
            if (tracker.quest.progress == 3)
            {
                GameObject.Find("QuestSignifier - Phrankus").GetComponent<ParticleSystem>().Play();
                tracker.descText.text = "Quest Complete: Return to Phrankus.";
            }
        }
        if (nameCheck.name.ToString() == "Phrankus" && tracker.quest.progress == 3)
        {
            tracker.CompleteQuest();
            tracker.titleText.text = "No Active Quest";
            tracker.descText.text = "Find Professor Emilia in the North Hall.";
            GameObject.Find("Quest5Icon").GetComponent<Image>().enabled = false;
            GameObject.Find("NoActiveQuestIcon").GetComponent<Image>().enabled = true;            
            GameObject.Find("North Hall").tag = "Interactable";
            GameObject.Find("Bonna").tag = "Untagged";
            GameObject.Find("Phrankus").tag = "Untagged";
            DoorIdentifier.SetActive(true);
        }
    }

    public void TalkToBonna()
    {
        tracker.quest.goal = 3;
    }

    public void changePos()
    {
        GameObject.Find("Phrankus").transform.position = GameObject.Find("PhrankusPos").transform.position;
        GameObject.Find("Bonna").transform.position = GameObject.Find("BonnaPos").transform.position;

        GameObject.Find("Phrankus").transform.rotation = GameObject.Find("PhrankusPos").transform.rotation;
        GameObject.Find("Bonna").transform.rotation = GameObject.Find("BonnaPos").transform.rotation;

        GameObject.Find("Analilia").transform.position = GameObject.Find("AnaliliaPos").transform.position;
        GameObject.Find("Analilia").transform.rotation = GameObject.Find("AnaliliaPos").transform.rotation;

        //also make the untagged to finish the quest
        GameObject.Find("Phrankus").tag = "Untagged";
        GameObject.Find("QuestSignifier - Phrankus").GetComponent<ParticleSystem>().Stop();
    }

}


