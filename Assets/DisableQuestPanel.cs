using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableQuestPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("QuestPanel").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
