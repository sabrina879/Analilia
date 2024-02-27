using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest4 : MonoBehaviour
{
    private QuestGiver tracker;
    public GameObject nameCheck;
    public bool hasApple;
    public bool hasEye;
    private GameObject Mary;
    private GameObject Koi;
    private GameObject Peeves;
    private GameObject PurpleJewel;
    private GameObject GreenJewel;
    private GameObject YellowJewel;
    private GameObject RedJewel;
    private GameObject OrangeJewel;
    private GameObject BlueJewel;

    // Start is called before the first frame update
    void Start()
    {
        hasApple = false;
        hasEye = false;
        Mary = GameObject.Find("Mourning Mary I");
        Koi = GameObject.Find("Madam Koi Koi II");
        Peeves = GameObject.Find("Peeves the Poltergeist III");
        PurpleJewel = GameObject.Find("PurpleJewel");
        GreenJewel = GameObject.Find("GreenJewel");
        YellowJewel = GameObject.Find("YellowJewel");
        RedJewel = GameObject.Find("RedJewel");
        OrangeJewel = GameObject.Find("OrangeJewel");
        BlueJewel = GameObject.Find("BlueJewel");
        tracker = GameObject.Find("Eye Lost It!").GetComponent<QuestGiver>();
        if (GameObject.Find("LadderQuestSignifier") !=null)
            GameObject.Find("LadderQuestSignifier").GetComponent<ParticleSystem>().Stop();
    }

    public void Apple()
    {
        GameObject.Find("Isadora").GetComponent<Quest4>().hasApple = true;
        tracker.quest.progress++;
        tracker.descText.text = "Bring the Apple to Isadora.";
       // GameObject.Find("Quest Apple").SetActive(true);

        //hasApple = true;

    }

    public bool checkHasApple()
    {
        return hasApple;
    }

    public bool checkHasEye()
    {
        return hasEye;
    }

    public void Checker()
    {
        if (nameCheck.name.ToString() == "Isadora" && tracker.quest.progress == 0)
        {
            //GameObject.Find("Hungus").tag = "Untagged";
            tracker.descText.text = "Find an Apple to Give Isadora. Hint: Check the Main Hall.";
            GameObject.Find("AppleChest").tag = "Interactable";
            Mary.tag = "Interactable";
            Koi.tag = "Interactable";
            Peeves.tag = "Interactable";
            PurpleJewel.tag = "Interactable";
            GreenJewel.tag = "Interactable";
            YellowJewel.tag = "Interactable";
            RedJewel.tag = "Interactable";
            OrangeJewel.tag = "Interactable";
            BlueJewel.tag = "Interactable";
            //GameObject.Find("Quest Apple").SetActive(true);
        }
        if (nameCheck.name.ToString() == "Isadora" && tracker.quest.progress == 1)
        {
            GameObject.Find("IsadoraQuestSignifier").GetComponent<ParticleSystem>().Stop();
            tracker.descText.text = "Quest Complete: Bring Hungus his Eye.";
            GameObject.Find("Hungus").GetComponent<Quest4>().hasEye = true;
            tracker.quest.progress++;
        }

        if (nameCheck.name.ToString() == "Hungus" && tracker.quest.progress == 2)
        {
            tracker.titleText.text = "No Active Quest";
            tracker.descText.text = "Maybe there's someone around here who can help me.";
            tracker.CompleteQuest();
            GameObject.Find("Trial 3 Gate").tag = "Interactable";
            GameObject.Find("NoActiveQuestIcon").GetComponent<Image>().enabled = true;
            GameObject.Find("Quest4Icon").GetComponent<Image>().enabled = false;


        }
    }

    public void TalkToHungus()
    {
        if(tracker.quest.progress == 0)
        {
            GameObject.Find("Ladder").tag = "Interactable";
            GameObject.Find("LadderQuestSignifier").GetComponent<ParticleSystem>().Play();
            GameObject.Find("HungusQuestSignifier").GetComponent<ParticleSystem>().Stop();
            GameObject.Find("NoActiveQuestIcon").GetComponent<Image>().enabled = false;
            GameObject.Find("Quest4Icon").GetComponent<Image>().enabled = true;
        }


    }
}
