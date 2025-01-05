using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;

    void Start()
    {
        // Load the saved volume level or use the default value (1.0f)
        float savedVolume = PlayerPrefs.GetFloat("VolumeLevel", 1.0f);
        volumeSlider.value = savedVolume;
        AudioListener.volume = savedVolume;

        // Add listener to handle changes in slider value
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    void SetVolume(float volume)
    {
        // Set the global volume and save the setting
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("VolumeLevel", volume);
    }
}
