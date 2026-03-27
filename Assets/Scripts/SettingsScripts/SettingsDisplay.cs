using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsDisplay : MonoBehaviour
{
    public const string SaveQualitySettingsKey = "quality_settings";
    public const string SaveDisplaySettingsKey = "display_settings";
    public const string SaveResolutionSettingsKey = "resolution_settings";

    public GameObject saveSettingsDataWindow;

    [Header("Dropdown")]
    [SerializeField] TMP_Dropdown qualityDropdown;
    [SerializeField] TMP_Dropdown displayDropdown;
    [SerializeField] TMP_Dropdown resolutionDropdown;

    [Header("Label")]
    [SerializeField] TMP_Text qualityLabel;
    [SerializeField] TMP_Text displayLabel;
    [SerializeField] TMP_Text resolutionLabel;

    public bool isHasEditSettingQuality = false;
    public bool isHasEditSettingDisplay = false;
    public bool isHasEditSettingResolution = false;

    Resolution[] resolutions;

    private void Awake()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++) 
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRateRatio + "Hz";
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();

        if (SceneManager.GetActiveScene().name == "GameScene") 
            LoadDisplaySettings(currentResolutionIndex);
        

        if (SceneManager.GetActiveScene().name == "MenuScene") 
            LoadDisplaySettings(currentResolutionIndex);
        


    }

    public void Quality(int qualityIndex) 
    {
        QualitySettings.SetQualityLevel(qualityIndex);

        qualityLabel.text = "Quality*";
        isHasEditSettingQuality = true;
    }

    public void Display(int displayIndex) 
    {
        FullScreenMode display = (FullScreenMode)displayIndex;
        Screen.fullScreenMode = display;

        displayLabel.text = "Display*";
        isHasEditSettingDisplay = true;
    }

    public void Resolution(int resolutionIndex) 
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        resolutionLabel.text = "Resolution*";
        isHasEditSettingResolution = true;
    }

    public void ConfirmSaveDataSettingsClickBtn()
    {
        PlayerPrefs.SetInt(SaveQualitySettingsKey, qualityDropdown.value);
        PlayerPrefs.SetInt(SaveDisplaySettingsKey, displayDropdown.value);
        PlayerPrefs.SetInt(SaveResolutionSettingsKey, resolutionDropdown.value);

        RemoveSpecialSign();

        saveSettingsDataWindow.SetActive(false);
    }

    public void NonConfirmSaveDataSettingsClickBtn() => saveSettingsDataWindow.SetActive(false);
    

    public void LoadDisplaySettings(int currentesolutionIndex) 
    {
        if (PlayerPrefs.HasKey(SaveQualitySettingsKey))
            qualityDropdown.value = PlayerPrefs.GetInt(SaveQualitySettingsKey);
        else
            qualityDropdown.value = 5;

        if (PlayerPrefs.HasKey(SaveDisplaySettingsKey))
            displayDropdown.value = PlayerPrefs.GetInt(SaveDisplaySettingsKey);
        else
            displayDropdown.value = 0;

        if (PlayerPrefs.HasKey(SaveResolutionSettingsKey))
            resolutionDropdown.value = PlayerPrefs.GetInt(SaveResolutionSettingsKey);
        else
            resolutionDropdown.value = currentesolutionIndex;

        RemoveSpecialSign();
    }

    public void RemoveSpecialSign() 
    {
        qualityLabel.text = "Quality";
        displayLabel.text = "Display";
        resolutionLabel.text = "Resolution";

        isHasEditSettingDisplay = false;
        isHasEditSettingQuality = false;
        isHasEditSettingResolution = false;
    }
}
