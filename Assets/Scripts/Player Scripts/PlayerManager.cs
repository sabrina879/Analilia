using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class PlayerManager : MonoBehaviour

{
    public int lives;

    void Start()
    {
        lives = 1;
    }

    public void IncrementLives()
    {
        lives++;
    }

}
