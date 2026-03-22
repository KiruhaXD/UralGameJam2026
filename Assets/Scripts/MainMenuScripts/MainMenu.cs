using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject menuWindow;
    public GameObject settingsWindow;

    public bool isShowSettings = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuWindow.SetActive(true);
            settingsWindow.SetActive(false);
            isShowSettings = false;
        }
    }
}
