using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest2_HideFairies : MonoBehaviour
{
    public GameObject fairy1;
    public GameObject fairy2;
    public GameObject fairy3;
    private QuestGiver tracker;
    void Start()
    {
        tracker = GameObject.Find("Hide n Seek!").GetComponent<QuestGiver>();

        if (tracker.quest.progress == 3)
        {
            fairy1.SetActive(false);
            fairy2.SetActive(false);
            fairy3.SetActive(false);
        }
    }

}
