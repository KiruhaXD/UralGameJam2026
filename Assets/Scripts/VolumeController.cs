using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] string[] volumeParametrs;
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider commonAudioSlider;

    [SerializeField] float volumeValue;
    [SerializeField] float multiplier = 20f;

    [ContextMenu("Delete Saves Volumes (Польз.)")]
    public void DeleteSavesKeys() 
    {
        for (int i = 0; i < volumeParametrs.Length; i++)
        {
            PlayerPrefs.DeleteKey(volumeParametrs[i]);
        }
    }

    private void Awake()
    {
        commonAudioSlider.onValueChanged.AddListener(HandleCommonAudioSliderValueChanged);
    }

    private void Start()
    {
        for (int i = 0; i < volumeParametrs.Length; i++)
        {
            volumeValue = PlayerPrefs.GetFloat(volumeParametrs[i], Mathf.Log10(commonAudioSlider.value) * multiplier);
        }

        commonAudioSlider.value = Mathf.Pow(10f, volumeValue / multiplier);
    }

    public void HandleCommonAudioSliderValueChanged(float value) 
    {
        volumeValue = Mathf.Log10(value) * multiplier;

        for (int i = 0; i < volumeParametrs.Length; i++) 
        {
            audioMixer.SetFloat(volumeParametrs[i], volumeValue);
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < volumeParametrs.Length; i++)
        {
            PlayerPrefs.SetFloat(volumeParametrs[i], volumeValue);
        }

    }
}
