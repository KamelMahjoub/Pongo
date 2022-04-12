using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace SlimUI.ModernMenu
{
    public class MenuManager : MonoBehaviour
    {
        Animator cameraObject;
        public enum Theme {custom1, custom2, custom3};
        [Header("Theme Settings")]
        public Theme theme;
        int themeIndex;
        public FlexibleUIData themeController;
        
        [Header("SFX")] 
        public AudioSource hoverSound;
        public AudioSource sliderSound;
        public AudioSource swooshSound;
        
        [Header("Menus")]
        public GameObject mainMenu;
        public GameObject menuButtons;
        public GameObject exitMenu;
        
        [Header("CANVAS")] 
        public GameObject creditsCanvas;
        public GameObject settingsCanvas;
        public GameObject matchCanvas;
        
        [Header("LOADING SCREEN")]
        public GameObject loadingMenu;
        public Slider loadBar;
        public TMP_Text finishedLoadingText;


        private void Awake()
        {
            Init();
        }

        public void Init()
        {
            cameraObject = transform.GetComponent<Animator>();
            InitMenu();
            SetThemeColors();
        }
        
        public void InitMenu()
        {
            exitMenu.SetActive(false);
            menuButtons.SetActive(true);
            mainMenu.SetActive(true);  
        }
        
        private void SetThemeColors(){
            if(theme == Theme.custom1){
                themeController.currentColor = themeController.custom1.graphic1;
                themeController.textColor = themeController.custom1.text1;
                themeIndex = 0;
            }else if(theme == Theme.custom2){
                themeController.currentColor = themeController.custom2.graphic2;
                themeController.textColor = themeController.custom2.text2;
                themeIndex = 1;
            }else if(theme == Theme.custom3){
                themeController.currentColor = themeController.custom3.graphic3;
                themeController.textColor = themeController.custom3.text3;
                themeIndex = 2;
            }
        }
        
        public void OpenMatchCanvas()
        {
            matchCanvas.SetActive(true);
        }
        
        public void OpenSettingsCanvas()
        {
            settingsCanvas.SetActive(true);
        }
        
        public void OpenCreditsCanvas()
        {
            creditsCanvas.SetActive(true);
        }
        
        public void CloseCanvas()
        {
            creditsCanvas.SetActive(false);
            settingsCanvas.SetActive(false);
            matchCanvas.SetActive(false);
            exitMenu.SetActive(false);
        }
        
        public void ReturnMenu()
        {
            CloseCanvas();
            mainMenu.SetActive(true);
        }
        
        public void Position2()
        {
            cameraObject.SetFloat("Animate", 1);
        }

        public void Position1()
        {
            cameraObject.SetFloat("Animate", 0);
        }
        
        public void QuitGame()
        {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
			 Application.Quit();
        #endif
        }
        
        public void QuitConfirmation()
        {
            exitMenu.SetActive(true);
        }
        
        
        
        
        
        
        
        
        
        




    }
}
