using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthIntroQuest : MonoBehaviour
{
    private QuestGiver tracker;
    public GameObject exitCollision;
    private GameObject player;
    public GameObject evilWitch;
    public GameObject DoorIdentifier;
    public GameObject cutScene;

    // Start is called before the first frame update
    void Start()
    {
      // Set Analilia prefab child UNactive so that she doesn't show up in
      // cut scene

      exitCollision.SetActive(false);
      player = GameObject.FindGameObjectWithTag("Player");

      GameObject analiliaChar;
      analiliaChar = player.transform.Find("Analilia").gameObject;
      analiliaChar.SetActive(false);
      player.GetComponent<Player>().enabled = false;

        tracker = GameObject.Find("LabyrinthIntro").GetComponent<QuestGiver>();
      if (tracker.quest.isActive == false && tracker.quest.isComplete == false)
      {
          // Player has interacted with Myrinn and quest can begin
          tracker.ShowActiveQuest();
          tracker.AcceptQuest();
          tracker.quest.goal = 1;
          tracker.titleText.text = "Welcome To The Labyrinth.";
          tracker.descText.text = "Talk to the Evil Witch";
      }
    }

    public void talkedToWitch()
    {
        tracker.descText.text = "Use the door to start Trial 1";
        exitCollision.SetActive(true);
        DoorIdentifier.SetActive(true);

        

        evilWitch.tag = "Untagged";
        tracker.CompleteQuest();
    }

    // Update is called once per frame
    void Update()
    {

        if (cutScene.activeSelf == false)
        {
            player.GetComponent<Player>().enabled = true;
            GameObject analiliaChar;
            analiliaChar = player.transform.Find("Analilia").gameObject;
            analiliaChar.SetActive(true);
        }

    }
}
