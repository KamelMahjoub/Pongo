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

        //Initializes the values/properties.
        private void Init()
        {
            defaultSliderValue = 0.2f;
            musicSlider.GetComponent<Slider>().value = defaultSliderValue;
        }
        
        //Hides the settings panels;
        private void DisablePanels()
        {
            panelSettings.SetActive(false);
            panelControls.SetActive(false);
            panelPowerups.SetActive(false);
        }

        //Hides the line effects on the panels.
        private void DisableLines()
        {
            lineSettings.SetActive(false);
            lineControls.SetActive(false);
            linePowerups.SetActive(false);
        }

        //Hides the settings menu.
        private void DisableMenu()
        {
            DisablePanels();
            DisableLines();
        }

        //Sets the settings menu as active.
        public void OpenSettingsPanel()
        {
            DisableMenu();
            panelSettings.SetActive(true);
            lineSettings.SetActive(true);
        }

        //Sets the controls menu as active.
        public void OpenControlsPanel()
        {
            DisableMenu();
            panelControls.SetActive(true);
            lineControls.SetActive(true);
        }

        //Sets the powerup menu as active.
        public void OpenPowerupsPanel()
        {
            DisableMenu();
            panelPowerups.SetActive(true);
            linePowerups.SetActive(true);
        }
        
        //Changes the value of the music slider.
        private void SaveMusicSliderValue ()
        {
            PlayerPrefs.SetFloat("MusicVolume", musicSlider.GetComponent<Slider>().value);
        }
        
    }
}
