using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest2_Fairies : MonoBehaviour
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
            fairy1.SetActive(true);
            fairy2.SetActive(true);
            fairy3.SetActive(true);
        }
    }

}
