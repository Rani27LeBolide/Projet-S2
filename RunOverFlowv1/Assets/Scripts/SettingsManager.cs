using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SettingsManager : MonoBehaviour
{
    public Toggle fullscreenToggle;
    public Dropdown resolutionDropdown;
    public Dropdown textureQualityDropdown;
    public Slider musicVolumeSlider;
    public GameManager gamesettings;
    public Resolution[] resolutions;
    public AudioSource musicSource;
    public Button applybutton;

    void OnEnable()
    {
        gamesettings = new GameManager();
        fullscreenToggle.onValueChanged.AddListener(delegate { OnFullscreenToggle(); });
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        textureQualityDropdown.onValueChanged.AddListener(delegate { OnTextureQualityChange(); });
        musicVolumeSlider.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });
        applybutton.onClick.AddListener(delegate { OnApplyButtonClick(); });

        resolutions = Screen.resolutions;
        foreach(Resolution resolution in resolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }
        LoadSetting();
    }
    public void OnFullscreenToggle()
    {
       gamesettings.Fullscreen= Screen.fullScreen = fullscreenToggle.isOn;
    }
    public void OnResolutionChange()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
        gamesettings.resolutionIndex = resolutionDropdown.value;
    }
    public void OnTextureQualityChange()
    {
        QualitySettings.masterTextureLimit= gamesettings.textureQuality = textureQualityDropdown.value;
    }
    public void OnMusicVolumeChange()
    {
        musicSource.volume =  gamesettings.musicVolume =musicVolumeSlider.value;
    }
    public void OnApplyButtonClick()
    {
        SaveSettings();
    }
    public void SaveSettings()
    {
        string JsonData = JsonUtility.ToJson(gamesettings,true);
        File.WriteAllText(Application.persistentDataPath+"gamesettings.json",JsonData);
    }
    public void LoadSetting()
    {
        gamesettings = JsonUtility.FromJson<GameManager>(File.ReadAllText(Application.persistentDataPath + "gamesettings.json"));
        musicVolumeSlider.value = gamesettings.musicVolume;
        textureQualityDropdown.value = gamesettings.textureQuality;
        resolutionDropdown.value = gamesettings.resolutionIndex;
        fullscreenToggle.isOn = gamesettings.Fullscreen;

        resolutionDropdown.RefreshShownValue();
    }
}
