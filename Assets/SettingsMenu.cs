using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;

    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> resOptions = new List<string>();
        int indexCurrentResolution = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            Resolution res = resolutions[i];
            string resOption = $"{res.width} x {res.height}";
            resOptions.Add(resOption);
            if (res.width == Screen.currentResolution.width && 
                res.height == Screen.currentResolution.height
            ) {
                indexCurrentResolution = i;
            }
        }
        resolutionDropdown.AddOptions(resOptions);
        resolutionDropdown.value = indexCurrentResolution;
        resolutionDropdown.RefreshShownValue();
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
