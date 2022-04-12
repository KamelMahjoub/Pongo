using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SlimUI.ModernMenu{
    public class SettingsMenu : MonoBehaviour
    {
        [Header("PANELS")] 
        [SerializeField]
        private GameObject panelSettings;
        [SerializeField]
        private GameObject panelControls;
        [SerializeField]
        private GameObject panelPowerups;

        [Header("HIGHLIGHT EFFECTS")] 
        [SerializeField]
        private GameObject lineSettings;
        [SerializeField]
        private GameObject lineControls;
        [SerializeField]
        private GameObject linePowerups;
        
        [Header("GAME SETTINGS")]
        [SerializeField]
        private GameObject musicSlider;

        [Header("VARIABLES")] 
        private float defaultSliderValue;


        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            defaultSliderValue = 0.2f;
            musicSlider.GetComponent<Slider>().value = defaultSliderValue;
        }
        
        private void DisablePanels()
        {
            panelSettings.SetActive(false);
            panelControls.SetActive(false);
            panelPowerups.SetActive(false);
        }

        private void DisableLines()
        {
            lineSettings.SetActive(false);
            lineControls.SetActive(false);
            linePowerups.SetActive(false);
        }

        private void DisableMenu()
        {
            DisablePanels();
            DisableLines();
        }

        public void OpenSettingsPanel()
        {
            DisableMenu();
            panelSettings.SetActive(true);
            lineSettings.SetActive(true);
        }

        public void OpenControlsPanel()
        {
            DisableMenu();
            panelControls.SetActive(true);
            lineControls.SetActive(true);
        }

        public void OpenPowerupsPanel()
        {
            DisableMenu();
            panelPowerups.SetActive(true);
            linePowerups.SetActive(true);
        }
        
        private void SaveMusicSliderValue ()
        {
            PlayerPrefs.SetFloat("MusicVolume", musicSlider.GetComponent<Slider>().value);
        }
        
    }
}
