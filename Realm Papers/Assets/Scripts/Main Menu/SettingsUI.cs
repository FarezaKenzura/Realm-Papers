using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace PaperRealms.UI.MainMenu 
{
    public class SettingsUI : MonoBehaviour
    {
        [Header("Resolution Setting")]
        [SerializeField] private TextMeshProUGUI resolutionText;
        private List<string> resolutions = new List<string> {  "1024 x 768",  "1280 x 720", "1920 x 1080" };

        [Header("Quality Setting")]
        [SerializeField] private TextMeshProUGUI qualityText;

        [Header("Volume Sliders")]
        [SerializeField] private Slider masterVolumeSlider;
        [SerializeField] private Slider musicVolumeSlider;
        [SerializeField] private Slider sfxVolumeSlider;
        //[SerializeField] private AudioManager audioManager;

        private int currentResolutionIndex;
        private int currentQualityIndex;

        private void Start()
        {
            currentResolutionIndex = PlayerPrefs.GetInt("ResolutionIndex", GetDefaultResolutionIndex());
            currentQualityIndex = PlayerPrefs.GetInt("QualityIndex", GetDefaultQualityIndex());
            
            ApplySettings();

            //masterVolumeSlider.onValueChanged.AddListener(value => SetVolume(masterVolumeSlider, value));
            //musicVolumeSlider.onValueChanged.AddListener(value => SetVolume(musicVolumeSlider, value));
            //sfxVolumeSlider.onValueChanged.AddListener(value => SetVolume(sfxVolumeSlider, value));
        }

        private void ApplySettings()
        {
            currentQualityIndex = Mathf.Clamp(currentQualityIndex, 0, QualitySettings.names.Length - 1);
            QualitySettings.SetQualityLevel(currentQualityIndex);

            UpdateResolutionText();
            UpdateQualityText();

            //masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", audioManager.GetVolume(AudioSourceType.Master));
            //musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", audioManager.GetVolume(AudioSourceType.Music));
            //sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", audioManager.GetVolume(AudioSourceType.SFX));

            //masterVolumeSlider.value = audioManager.GetVolume(AudioSourceType.Master);
            //musicVolumeSlider.value = audioManager.GetVolume(AudioSourceType.Music);
            //sfxVolumeSlider.value = audioManager.GetVolume(AudioSourceType.SFX);
        }

        #region Resolution

        public void NextResolution()
        {
            currentResolutionIndex = Mathf.Min(currentResolutionIndex + 1, resolutions.Count - 1);
            SetResolution(currentResolutionIndex);
            UpdateResolutionText();
        }

        public void PreviousResolution()
        {
            currentResolutionIndex = Mathf.Max(currentResolutionIndex - 1, 0);
            SetResolution(currentResolutionIndex);
            UpdateResolutionText();
        }

        private void SetResolution(int resolutionIndex)
        {
            string[] resolutionValues = resolutions[resolutionIndex].Split('x');
            int width = int.Parse(resolutionValues[0].Trim());
            int height = int.Parse(resolutionValues[1].Trim());

            Screen.SetResolution(width, height, Screen.fullScreen);

            PlayerPrefs.SetInt("ResolutionIndex", resolutionIndex);
        }

        private void UpdateResolutionText()
        {
            string currentResolution = resolutions[currentResolutionIndex];

            string resolutionLabel = GetResolutionLabel(currentResolution);

            resolutionText.text = resolutionLabel;
        }

        private int GetDefaultResolutionIndex()
        {
            return resolutions.IndexOf("1920 x 1080");
        }

        private string GetResolutionLabel(string resolution)
        {
            if (resolution.Contains("1920 x 1080"))
            {
                return "1080p";
            }
            else if (resolution.Contains("1280 x 720"))
            {
                return "720p";
            }
            else if (resolution.Contains("1024 x 768"))
            {
                return "480p";
            }
            else
            {
                return "Unknown";
            }
        }

        #endregion

        #region Quality
        public void NextQuality()
        {
            currentQualityIndex = Mathf.Min(currentQualityIndex + 1, QualitySettings.names.Length - 1);
            QualitySettings.SetQualityLevel(currentQualityIndex);
            PlayerPrefs.SetInt("QualityIndex", currentQualityIndex);
            UpdateQualityText();
        }

        public void PreviousQuality()
        {
            currentQualityIndex = Mathf.Max(currentQualityIndex - 1, 0);
            QualitySettings.SetQualityLevel(currentQualityIndex);
            PlayerPrefs.SetInt("QualityIndex", currentQualityIndex);
            UpdateQualityText();
        }

        private void UpdateQualityText()
        {
            qualityText.text = QualitySettings.names[currentQualityIndex];
        }

        private int GetDefaultQualityIndex()
        {
            int defaultQualityIndex = QualitySettings.GetQualityLevel();
            return Mathf.Clamp(defaultQualityIndex, 0, QualitySettings.names.Length - 1);
        }

        #endregion

        #region Volume

        /*public void SetVolume(Slider slider, float volume)
        {
            if (slider == masterVolumeSlider)
            {
                audioManager.SetVolume(AudioSourceType.Master, volume);
            }
            else if (slider == musicVolumeSlider)
            {
                audioManager.SetVolume(AudioSourceType.Music, volume);
            }
            else if (slider == sfxVolumeSlider)
            {
                audioManager.SetVolume(AudioSourceType.SFX, volume);
            }

            PlayerPrefs.SetFloat("MasterVolume", masterVolumeSlider.value);
            PlayerPrefs.SetFloat("MusicVolume", musicVolumeSlider.value);
            PlayerPrefs.SetFloat("SFXVolume", sfxVolumeSlider.value);
        }*/

        #endregion
    }
}