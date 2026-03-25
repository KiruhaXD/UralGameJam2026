using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] MainMenuButton mainMenuButton;

    [SerializeField] Settings settings;

    public GameObject menuWindow;
    public GameObject settingsWindow;
    public GameObject authorsWindow;

    public bool isShowSettings = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingsWindow.activeSelf == true) 
            {
                if (settings.isHasEditSettingDisplay == true ||
                settings.isHasEditSettingQuality == true || settings.isHasEditSettingResolution == true)
                {
                    settings.saveSettingsDataWindow.SetActive(true);
                }

                else if (settings.isHasEditSettingDisplay == false ||
                settings.isHasEditSettingQuality == false || settings.isHasEditSettingResolution == false) 
                {
                    settingsWindow.SetActive(false);
                    ShowMainMenu();
                }

            }

            else if (authorsWindow.activeSelf == true) 
            {
                authorsWindow.SetActive(false);
                ShowMainMenu();
            }

        }
    }

    public void ShowMainMenu() => menuWindow.SetActive(true);
    
}
