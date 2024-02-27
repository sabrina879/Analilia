using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPoint : MonoBehaviour
{
    private GameObject player;
    private GameObject spawn;
    // Start is called before the first frame update


    void Awake()
    {

    }

    void OnEnable()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        Time.timeScale = 1;
        player = GameObject.FindGameObjectWithTag("Player");

        if (sceneName == "Labyrinth Intro")
        {
            spawn = GameObject.Find("SpawnIntro");

            GameObject analiliaChar;
            analiliaChar = player.transform.Find("Analilia").gameObject;
            analiliaChar.SetActive(false);
            player.transform.position = spawn.transform.position;

        }
        if (sceneName == "Quest 1 & 2 - Rune Me This")
        {
            spawn = GameObject.Find("StartSpawn");
            player.transform.position = spawn.transform.position;
        }

        if (sceneName == "Quest 2 - Hide n Seek (Sorcerer's Room)")
        {
            spawn = GameObject.Find("Quest2Spawn");
            player.transform.position = spawn.transform.position;
        }
        if (sceneName == "Quest 3 - Representative")
        {
            spawn = GameObject.Find("Quest3Spawn");
            player.transform.position = spawn.transform.position;
        }
        if (sceneName == "Quest 4 - Eye Lost It! (Ogre Hallway)")
        {
            spawn = GameObject.Find("Quest4Spawn");
            player.transform.position = spawn.transform.position;
        }
        if (sceneName == "Quest 4 - Eye Lost It! (Witch Hut)")
        {
            spawn = GameObject.Find("WitchSpawn");
            player.transform.position = spawn.transform.position;
        }
        if (sceneName == "Quest 5 - Tome of Parallels")
        {
            spawn = GameObject.Find("Quest5Spawn");
            player.transform.position = spawn.transform.position;
        }
        if (sceneName == "Quest 6 - Potion Problems")
        {
            spawn = GameObject.Find("SpawnQuest6");
            player.transform.position = spawn.transform.position;
        }
        if (sceneName == "Quest 7 - Tomb Troubles")
        {
            spawn = GameObject.Find("Spawn");
            player.transform.position = spawn.transform.position;
        }
        if (sceneName == "Quest 7 - 8 Transition")
        {
            spawn = GameObject.Find("SpawnTransition");
            player.transform.position = spawn.transform.position;
        }
        if (sceneName == "Quest 8 - Cave of Confidence")
        {
            spawn = GameObject.Find("Quest8Spawn");
            player.transform.position = spawn.transform.position;
        }
        if (sceneName == "Quest 9 - Self Reflection")
        {
            spawn = GameObject.Find("Quest9Spawn");
            player.transform.position = spawn.transform.position;
        }
        if (sceneName == "EndingOffice")
        {
            spawn = GameObject.Find("SpawnEnding");
            player.transform.position = spawn.transform.position;
        }
    }

    public void introTriggerPlayer()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        Time.timeScale = 1;
        player = GameObject.FindGameObjectWithTag("Player");

        if (sceneName == "Labyrinth Intro")
        {
            spawn = GameObject.Find("SpawnIntro");
            player.transform.position = spawn.transform.position;
        }
    }



    // Update is called once per frame
    void Update()
    {

    }
}
