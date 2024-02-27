using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.SerializableAttribute]

public class Quest
{
    public bool isActive; //did you press E to gain accept the quest?
    public bool isComplete;

    public string title; // title of quest
    public string description; // desc of quest

    public int reward; // reward?? eyeball += reward for Eye Lost It?

    public int progress;
    public int goal; // numeric goal (Ex: Interacting with multiple NPC's)







}
