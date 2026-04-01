using UnityEngine;
using UnityEngine.UI;

public class SettingsMouseSensivity : MonoBehaviour
{
    public const string MouseSensivityKey = "mouse_sensivity";

    [SerializeField] Slider sensivitySlider;

    [Header("Settings")]
    public float currentMouseSensivity = 500f;

    float minSensivity = 100f;
    float maxSensivity = 1000f;

    [ContextMenu("Delete Saves Sensivity (Польз.)")]
    public void DeleteSavesKeys() 
    {
        PlayerPrefs.DeleteKey(MouseSensivityKey);
    }

    private void Awake()
    {
        ChangeSensivity();

        if(PlayerPrefs.HasKey(MouseSensivityKey))
            sensivitySlider.value = PlayerPrefs.GetFloat(MouseSensivityKey);
    }

    public void ChangeSensivity() 
    {
        sensivitySlider.value = (currentMouseSensivity - minSensivity) / (maxSensivity - minSensivity);

        sensivitySlider.onValueChanged.AddListener(value =>
        {
            currentMouseSensivity = Mathf.Max(minSensivity, value * maxSensivity);
        });
    }

    private void OnDisable()
    {
        sensivitySlider.onValueChanged.RemoveAllListeners();

        PlayerPrefs.SetFloat(MouseSensivityKey, sensivitySlider.value);
    }


}
