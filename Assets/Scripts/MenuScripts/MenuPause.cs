using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public int countPressKeyEscape = 0;

    [SerializeField] ChoiseEffectController choiseEffectController;

    [SerializeField] GameObject menuPausePanel;

    [SerializeField] GameObject menuSettings;

    [Header("Array Units Audio")]
    [SerializeField] AudioSource[] audioSourcesRun;

    [Header("Background Audio")]
    [SerializeField] AudioSource audioBackgroundSource;

    [Header("Repair Audio")]
    [SerializeField] AudioSource audioRepairSourceFixBrokenRobot, audioRepairSourceChargeBrokenRobot;

    public bool isShowSettings = false;

    public bool pauseMenuActive = false;

    [SerializeField] RepairRobotBrotherController repairRobotBrother;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (countPressKeyEscape)
            {
                case 0:
                    ShowCursor();
                    Pause();
                    break;

                case 1:
                    Continue();
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isShowSettings == true) 
        {
            ShowCursor();

            Pause();

            isShowSettings = false;

            menuSettings.SetActive(false);
        }
    }

    public void Pause() 
    {
        ShowCursor();

        menuPausePanel.SetActive(true);

        pauseMenuActive = true;

        countPressKeyEscape = 1;

        //for (int i = 0; i < audioSourcesRun.Length; i++)
          //audioSourcesRun[i].Pause();

        //audioRepairSourceFixBrokenRobot.Pause();
        //audioRepairSourceChargeBrokenRobot.Pause();

        audioBackgroundSource.Pause();


        Time.timeScale = 0f;


    }

    public void RestartLevel() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Continue()
    {
        if (repairRobotBrother.isCheckBrokenRobot == true)
            ShowCursor();

        else
            HideCursor();

        if (choiseEffectController.menuChoiseEffectActive == true)
            ShowCursor();

        menuPausePanel.SetActive(false);

        pauseMenuActive = false;

        countPressKeyEscape = 0;

        Time.timeScale = 1f;

        //for (int i = 0; i < audioSourcesRun.Length; i++)
          //  audioSourcesRun[i].Play();

        //audioRepairSourceFixBrokenRobot.Play();
        //audioRepairSourceChargeBrokenRobot.Play();

        audioBackgroundSource.Play();

    }

    public void Settings() 
    {
        isShowSettings = true;

        menuPausePanel.SetActive(false);
        menuSettings.SetActive(true);

        ShowCursor();
    }

    public void ExitInMenu() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    } 

    public void ExitGame() => Application.Quit();

    public void HideCursor() 
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ShowCursor() 
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void MenuPauseActive() 
    {
        if (pauseMenuActive == true)
            ShowCursor();

        else
            HideCursor();
    }
}
