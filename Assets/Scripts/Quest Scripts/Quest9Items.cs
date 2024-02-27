using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest9Items : MonoBehaviour
{

    // Global Variables
    public static int currentPedestal = 0;
    private QuestGiver tracker;
    
    // Pedestal 1 (Book)
    public GameObject Pedestal1;
    public GameObject correctPed1;
    public GameObject incorrectPed1;
    public GameObject book;

    // Pedestal 2 (Key)
    public GameObject Pedestal2;
    public GameObject correctPed2;
    public GameObject incorrectPed2;
    public GameObject key;

    // Pedestal 3 (Potion)
    public GameObject Pedestal3;
    public GameObject correctPed3;
    public GameObject incorrectPed3;
    public GameObject potion;

    // Pedestal 4 (Candle)
    public GameObject Pedestal4;
    public GameObject correctPed4;
    public GameObject incorrectPed4;
    public GameObject candle;

    // Pedestal 5 (Mushroom)
    public GameObject Pedestal5;
    public GameObject correctPed5;
    public GameObject incorrectPed5;
    public GameObject mushroom;

    // Pedestal 6 (Scroll)
    public GameObject Pedestal6;
    public GameObject correctPed6;
    public GameObject incorrectPed6;
    public GameObject scroll;

    // Pedestal 7 (Arrow)
    public GameObject Pedestal7;
    public GameObject correctPed7;
    public GameObject incorrectPed7;
    public GameObject arrow;

    // Pedestal 8 (Crystal)
    public GameObject Pedestal8;
    public GameObject correctPed8;
    public GameObject incorrectPed8;
    public GameObject crystal;

    void Start()
    {
        tracker = GameObject.Find("Self Reflection").GetComponent<QuestGiver>();
    }

    public void talkToEvilWitch()
    {
        if(currentPedestal == 0)
        {
            
            tracker.ShowActiveQuest();
            tracker.AcceptQuest();
            Pedestal1.tag = "Interactable";
            currentPedestal++;
            GameObject.Find("Witch").tag = "Untagged";
            tracker.quest.goal = 8;
            tracker.titleText.text = "Reflections";
            tracker.descText.text = "Place the correct items on the pedestals."  + " (" + tracker.quest.progress.ToString() + "/" + tracker.quest.goal.ToString() + ")";
            GameObject.Find("NoActiveQuestIcon").GetComponent<Image>().enabled = false;
            GameObject.Find("Quest9Icon").GetComponent<Image>().enabled = true;
        }
        
    }

    private void incorrectParticle()
    {
        switch(currentPedestal)
        {
            case 1:
            incorrectPed1.SetActive(true);
            break;

            case 2:
            incorrectPed2.SetActive(true);
            break;

            case 3:
            incorrectPed3.SetActive(true);
            break;

            case 4:
            incorrectPed4.SetActive(true);
            break;

            case 5:
            incorrectPed5.SetActive(true);
            break;

            case 6:
            incorrectPed6.SetActive(true);
            break;

            case 7:
            incorrectPed7.SetActive(true);
            break;

            case 8:
            incorrectPed8.SetActive(true);
            break;
        }
    }

    public void checkBook()
    {
        if(currentPedestal == 1)
        {
            book.SetActive(true);
            incorrectPed1.SetActive(false);
            correctPed1.SetActive(true);
            currentPedestal++;
            Pedestal1.tag = "Untagged";
            Pedestal2.tag = "Interactable";
            tracker.quest.progress++;
            tracker.descText.text = "Place the correct items on the pedestals."  + " (" + tracker.quest.progress.ToString() + "/" + tracker.quest.goal.ToString() + ")";            
        }
        else
            incorrectParticle();
    }

    public void checkKey()
    {
        if(currentPedestal == 2)
        {
            key.SetActive(true);
            incorrectPed2.SetActive(false);
            correctPed2.SetActive(true);
            currentPedestal++;
            Pedestal2.tag = "Untagged";
            Pedestal3.tag = "Interactable";
            tracker.quest.progress++;
            tracker.descText.text = "Place the correct items on the pedestals."  + " (" + tracker.quest.progress.ToString() + "/" + tracker.quest.goal.ToString() + ")";
            
        }
        else
            incorrectParticle();
    }

    public void checkPotion()
    {
        if(currentPedestal == 3)
        {
            potion.SetActive(true);
            incorrectPed3.SetActive(false);
            correctPed3.SetActive(true);
            currentPedestal++;
            Pedestal3.tag = "Untagged";
            Pedestal4.tag = "Interactable";
            tracker.quest.progress++;
            tracker.descText.text = "Place the correct items on the pedestals."  + " (" + tracker.quest.progress.ToString() + "/" + tracker.quest.goal.ToString() + ")";
            
        }
        else
            incorrectParticle();        
    }

    public void checkCandle()
    {
        if(currentPedestal == 4)
        {
            candle.SetActive(true);
            incorrectPed4.SetActive(false);
            correctPed4.SetActive(true);
            currentPedestal++;
            Pedestal4.tag = "Untagged";
            Pedestal5.tag = "Interactable";
            tracker.quest.progress++;
            tracker.descText.text = "Place the correct items on the pedestals."  + " (" + tracker.quest.progress.ToString() + "/" + tracker.quest.goal.ToString() + ")";
            
        }
        else
            incorrectParticle();        
    }

    public void checkMushroom()
    {
        if(currentPedestal == 5)
        {
            mushroom.SetActive(true);
            incorrectPed5.SetActive(false);
            correctPed5.SetActive(true);
            currentPedestal++;
            Pedestal5.tag = "Untagged";
            Pedestal6.tag = "Interactable";
            tracker.quest.progress++;
            tracker.descText.text = "Place the correct items on the pedestals."  + " (" + tracker.quest.progress.ToString() + "/" + tracker.quest.goal.ToString() + ")";
            
        }
        else
            incorrectParticle();        
    }

    public void checkScroll()
    {
        if(currentPedestal == 6)
        {
            scroll.SetActive(true);
            incorrectPed6.SetActive(false);
            correctPed6.SetActive(true);
            currentPedestal++;
            Pedestal6.tag = "Untagged";
            Pedestal7.tag = "Interactable";
            tracker.quest.progress++;
            tracker.descText.text = "Place the correct items on the pedestals."  + " (" + tracker.quest.progress.ToString() + "/" + tracker.quest.goal.ToString() + ")";
            
        }
        else
            incorrectParticle();        
    }

    public void checkArrow()
    {
        if(currentPedestal == 7)
        {
            arrow.SetActive(true);
            incorrectPed7.SetActive(false);
            correctPed7.SetActive(true);
            currentPedestal++;
            Pedestal7.tag = "Untagged";
            Pedestal8.tag = "Interactable";
            tracker.quest.progress++;
            tracker.descText.text = "Place the correct items on the pedestals."  + " (" + tracker.quest.progress.ToString() + "/" + tracker.quest.goal.ToString() + ")";
            
        }
        else
            incorrectParticle();        
    }

    public void checkCrystal()
    {
        if(currentPedestal == 8)
        {
            crystal.SetActive(true);
            incorrectPed8.SetActive(false);
            correctPed8.SetActive(true);
            currentPedestal++;
            Pedestal8.tag = "Untagged";
            GameObject.Find("Witch").tag = "Interactable";
            tracker.quest.progress++;
            tracker.descText.text = "Talk to the Evil Witch.";
            
        }
        else
            incorrectParticle();        
    }
}
