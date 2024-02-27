using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest6 : MonoBehaviour
{
    private bool ProfhasSpoken;
    private QuestGiver tracker;
    public GameObject NPC;
    private bool []hasTalkedToStudent = new bool[5];
    public GameObject potions;

    public GameObject player;
    public GameObject potionScene;
    public GameObject potionOnDesk;



    //(Vinfi, Carvos, Viktas, Indressa, Sabreya) IN ORDER
    //Don't increment progress once we have spoken to student.

    void Start()
    {
        ProfhasSpoken = false;
        tracker = GameObject.Find("Potion Problems").GetComponent<QuestGiver>();

        if (tracker.quest.isActive == false && tracker.quest.isComplete == false)
        {
            // Player has interacted with Myrinn and quest can begin
            tracker.ShowActiveQuest();
            tracker.AcceptQuest();
        }

        GameObject.Find("QuestSignifier - Indressa").GetComponent<ParticleSystem>().Stop();
        GameObject.Find("QuestSignifier - Carvos").GetComponent<ParticleSystem>().Stop();
        GameObject.Find("QuestSignifier - Vinfi").GetComponent<ParticleSystem>().Stop();
        GameObject.Find("QuestSignifier - Viktas").GetComponent<ParticleSystem>().Stop();
        GameObject.Find("QuestSignifier - Sabreya").GetComponent<ParticleSystem>().Stop();
        GameObject.Find("QuestSignifier - Potion Table").GetComponent<ParticleSystem>().Stop();


    }

    public void Checker()
    {
        if (ProfhasSpoken == false && NPC.name.ToString() == "Professor Emilia")
        {
            ProfhasSpoken = true;
            tracker.quest.goal = 5;
            tracker.titleText.text = "Potion Problems";
            tracker.descText.text = "Talk to the students to determine the best potion solution." + " (" + tracker.quest.progress.ToString() + "/" + tracker.quest.goal.ToString() + ")";
            GameObject.Find("Vinfi").tag = "Interactable";
            GameObject.Find("Carvos").tag = "Interactable";
            GameObject.Find("Viktas").tag = "Interactable";
            GameObject.Find("Indressa").tag = "Interactable";
            GameObject.Find("Sabreya").tag = "Interactable";
            GameObject.Find("QuestSignifier - Indressa").GetComponent<ParticleSystem>().Play();
            GameObject.Find("QuestSignifier - Carvos").GetComponent<ParticleSystem>().Play();
            GameObject.Find("QuestSignifier - Vinfi").GetComponent<ParticleSystem>().Play();
            GameObject.Find("QuestSignifier - Viktas").GetComponent<ParticleSystem>().Play();
            GameObject.Find("QuestSignifier - Sabreya").GetComponent<ParticleSystem>().Play();
            GameObject.Find("QuestSignifier - Professor Emilia").GetComponent<ParticleSystem>().Stop();
            GameObject.Find("NoActiveQuestIcon").GetComponent<Image>().enabled = false;
            GameObject.Find("Quest6Icon").GetComponent<Image>().enabled = true; 

        }

        else if (!hasTalkedToStudent[0] && NPC.name.ToString() == "Vinfi")
        {
            GameObject.Find("QuestSignifier - Vinfi").GetComponent<ParticleSystem>().Stop();
            hasTalkedToStudent[0] = true;
            tracker.quest.progress++;
            tracker.descText.text = "Talk to the students to determine the best potion solution." + " (" + tracker.quest.progress.ToString() + "/" + tracker.quest.goal.ToString() + ")";
        }
        else if (!hasTalkedToStudent[1] && NPC.name.ToString() == "Carvos")
        {
            GameObject.Find("QuestSignifier - Carvos").GetComponent<ParticleSystem>().Stop();

            hasTalkedToStudent[1] = true;
            tracker.quest.progress++;
            tracker.descText.text = "Talk to the students to determine the best potion solution." + " (" + tracker.quest.progress.ToString() + "/" + tracker.quest.goal.ToString() + ")";
        }
        else if (!hasTalkedToStudent[2] && NPC.name.ToString() == "Viktas")
        {
            GameObject.Find("QuestSignifier - Viktas").GetComponent<ParticleSystem>().Stop();

            hasTalkedToStudent[2] = true;
            tracker.quest.progress++;
            tracker.descText.text = "Talk to the students to determine the best potion solution." + " (" + tracker.quest.progress.ToString() + "/" + tracker.quest.goal.ToString() + ")";
        }
        else if (!hasTalkedToStudent[3] && NPC.name.ToString() == "Indressa")
        {
            GameObject.Find("QuestSignifier - Indressa").GetComponent<ParticleSystem>().Stop();

            hasTalkedToStudent[3] = true;
            tracker.quest.progress++;
            tracker.descText.text = "Talk to the students to determine the best potion solution." + " (" + tracker.quest.progress.ToString() + "/" + tracker.quest.goal.ToString() + ")";
        }
        else if (!hasTalkedToStudent[4] && NPC.name.ToString() == "Sabreya")
        {
            GameObject.Find("QuestSignifier - Sabreya").GetComponent<ParticleSystem>().Stop();

            hasTalkedToStudent[4] = true;
            tracker.quest.progress++;
            tracker.descText.text = "Talk to the students to determine the best potion solution." + " (" + tracker.quest.progress.ToString() + "/" + tracker.quest.goal.ToString() + ")";
        }

        if (tracker.quest.progress == tracker.quest.goal && NPC.name.ToString() != "Professor Emilia")
        {
            tracker.descText.text = "Create the correct potion at the alchemy table.";
            GameObject.Find("PotionTable").tag = "Interactable";
            GameObject.Find("QuestSignifier - Potion Table").GetComponent<ParticleSystem>().Play();

        }

    }

    public void changeToPotionScene()
    {
        potionScene.SetActive(true);

        potionOnDesk.SetActive(false);

        //player.SetActive(false);

        potions.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        tracker.descText.text = "Determine the best 3 ingredients.";

    }

    public void changeToPlayerCorrect()
    {
        GameObject.Find("QuestSignifier - Professor Emilia").GetComponent<ParticleSystem>().Play();
        GameObject.Find("QuestSignifier - Potion Table").GetComponent<ParticleSystem>().Stop();

        GameObject.Find("PotionTable").tag = "Untagged";

        potionOnDesk.SetActive(true);

       // player.SetActive(true);

        potionScene.SetActive(false);
        potions.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        tracker.descText.text = "Quest Complete! Return to Professor Emilia.";

    }

    public void changeToPlayerIncorrect()
    {
        //RESET ICONS
        GameObject.Find("Guar Gum Icon").GetComponent<Image>().enabled = false;
        GameObject.Find("Honey Icon").GetComponent<Image>().enabled = false;
        GameObject.Find("Witch Hazel Icon").GetComponent<Image>().enabled = false;
        GameObject.Find("Base Name").GetComponent<Text>().text = "";

        GameObject.Find("Spider Eggs Icon").GetComponent<Image>().enabled = false;
        GameObject.Find("Cave Moss Icon").GetComponent<Image>().enabled = false;
        GameObject.Find("Spotted Mushroom Icon").GetComponent<Image>().enabled = false;
        GameObject.Find("Reactant Name").GetComponent<Text>().text = "";

        GameObject.Find("Elderflower Icon").GetComponent<Image>().enabled = false;
        GameObject.Find("Tangleweed Icon").GetComponent<Image>().enabled = false;
        GameObject.Find("Mint Leaves Icon").GetComponent<Image>().enabled = false;
        GameObject.Find("Extract Name").GetComponent<Text>().text = "";



        GameObject.Find("QuestSignifier - Potion Table").GetComponent<ParticleSystem>().Play();

        potionOnDesk.SetActive(true);

        // player.SetActive(true);

        potionScene.SetActive(false);
        potions.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        tracker.descText.text = "Incorrect Potion! Hint: Talk to the students again.";
    }


}
