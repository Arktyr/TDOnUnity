using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace UI.Settings
{
    public class Settings : MonoBehaviour
    {
        public TMP_Dropdown resolutionDropDown;
        public TMP_Dropdown qualityDropDown;
        public AudioMixer audioMixer;
        public float currentVolume;
        public Slider slider;
        
        Resolution[] _resolutions;

        private void Start()
        {
            resolutionDropDown.ClearOptions();
            List<string> options = new List<string>();
            _resolutions = Screen.resolutions;
            int currentResolutionIndex = 0;
            
            for (int i=0; i <_resolutions.Length; i++)
            {
                string option = _resolutions[i].width + "x" + _resolutions[i].height + " " +
                                _resolutions[i].refreshRateRatio + "Hz";
                options.Add(option);
                if (_resolutions[i].width == Screen.currentResolution.width &&
                    _resolutions[i].height == Screen.currentResolution.height) currentResolutionIndex = i;
            }
            resolutionDropDown.AddOptions(options);
            resolutionDropDown.RefreshShownValue();
            LoadSettings(currentResolutionIndex);
        }

        public void SetFullScreen(bool isFullScreen)
        {
            Screen.fullScreen = isFullScreen;
        }

        public void SetResolution(int resolutionIndex)
        {
            Resolution resolution = _resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        }

        public void SetQuality(int qualityIndex)
        {
            QualitySettings.SetQualityLevel(qualityIndex);
        }

        public void ExitSettings()
        {
            Application.Quit();
        }

        public void SaveSettings()
        {
            PlayerPrefs.SetInt("QualitySettingPreference", qualityDropDown.value);
            PlayerPrefs.SetInt("ResolutionPreference", resolutionDropDown.value);
            PlayerPrefs.SetInt("FullscreenPreference", Convert.ToInt32(Screen.fullScreen));
            PlayerPrefs.SetFloat("SoundVolume", currentVolume);
        }

        private void LoadSettings(int currentResolutionIndex)
        {
            if (PlayerPrefs.HasKey("QualitySettingPreference"))
                qualityDropDown.value = PlayerPrefs.GetInt("QualitySettingPreference");
            else
                qualityDropDown.value = 3;
            if (PlayerPrefs.HasKey("ResolutionPreference"))
                resolutionDropDown.value = PlayerPrefs.GetInt("ResolutionPreference");
            else
                resolutionDropDown.value = currentResolutionIndex;
            if (PlayerPrefs.HasKey("FullscreenPreference"))
                Screen.fullScreen = Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
            else
                Screen.fullScreen = true;
            if (PlayerPrefs.HasKey("SoundVolume"))
                slider.value = PlayerPrefs.GetFloat("SoundVolume");
            else
                slider.value = -40;
        }

        public void SetSoundVolume(float value)
        {
            audioMixer.SetFloat("Volume", value);
            currentVolume = value;
        }
    }
}
