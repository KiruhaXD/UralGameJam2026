using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public int countPressKeyEscape = 0;

    [SerializeField] GameObject menuPausePanel;

    [SerializeField] GameObject menuSettings;

    [Header("Array Units Audio")]
    [SerializeField] AudioSource[] audioSourcesRun;

    [Header("Background Audio")]
    [SerializeField] AudioSource audioBackgroundSource;

    public bool isShowSettings = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (countPressKeyEscape)
            {
                case 0:
                    Pause();
                    break;

                case 1:
                    Continue();
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isShowSettings == true) 
        {
            isShowSettings = false;

            menuSettings.SetActive(false);

            Pause();
        }
    }

    public void Pause() 
    {
        menuPausePanel.SetActive(true);

        ShowCursor();

        countPressKeyEscape = 1;

        for (int i = 0; i < audioSourcesRun.Length; i++)
            audioSourcesRun[i].Pause();

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
        menuPausePanel.SetActive(false);

        HideCursor();

        countPressKeyEscape = 0;

        Time.timeScale = 1f;

        audioBackgroundSource.Play();
    }

    public void Settings() 
    {
        isShowSettings = true;

        menuPausePanel.SetActive(false);
        menuSettings.SetActive(true);
    }

    public void ExitInMenu() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    } 

    public void ExitGame() => Application.Quit();

    private void HideCursor() 
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void ShowCursor() 
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
