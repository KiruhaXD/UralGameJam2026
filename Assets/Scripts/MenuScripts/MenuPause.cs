using System;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    public int countPressKeyEscape = 0;

    [SerializeField] GameObject menuPausePanel;

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

    }

    public void Pause() 
    {
        menuPausePanel.SetActive(true);

        ShowCursor();

        countPressKeyEscape = 1;

        Time.timeScale = 0f;
    }

    public void Continue() 
    {
        menuPausePanel.SetActive(false);

        HideCursor();

        countPressKeyEscape = 0;

        Time.timeScale = 1f;
    }

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
