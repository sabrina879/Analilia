using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject QuestPanelUI;
    public GameObject settingsUI;

    public GameObject Trial1;
    public GameObject Trial2;
    public GameObject Trial3;
    public GameObject Trial4;
    public GameObject Trial5;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else 
            {
                Pause();
            }
        }
    }

    public void Resume () 
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameObject.Find("Main Camera 1").GetComponent<MouseLook>().enabled = true;
        pauseMenuUI.SetActive(false);
        QuestPanelUI.SetActive(true);
        settingsUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        GameObject.Find("Main Camera 1").GetComponent<MouseLook>().enabled = false;
        pauseMenuUI.SetActive(true);
        QuestPanelUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Trial1.SetActive(false);
        Trial2.SetActive(false);
        Trial3.SetActive(false);
        Trial4.SetActive(false);
        Trial5.SetActive(false);

    }

    public void QuitGame()
    {
        Application.Quit();
    }












}
