using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


namespace SlimUI.ModernMenu
{
    public class MenuManager : MonoBehaviour
    {
        Animator cameraObject;
        
        [Header("THEME SETTINGS")]
        public FlexibleUIData themeController;
        
        [Header("SFX")] 
        [SerializeField]
        private AudioSource hoverSound;
        [SerializeField]
        private AudioSource sliderSound;
        [SerializeField]
        private AudioSource swooshSound;
        
        [Header("MENUS")]
        [SerializeField]
        private GameObject mainMenu;
        [SerializeField]
        private GameObject menuButtons;
        [SerializeField]
        private GameObject exitMenu;

        [Header("CANVAS")] 
        [SerializeField]
        private GameObject creditsCanvas;
        [SerializeField]
        private GameObject settingsCanvas;
        [SerializeField]
        private GameObject matchCanvas;
        

        private void Awake()
        {
            Init();
        }
        
        //Initializes the variables        
        private void Init()
        {
            cameraObject = transform.GetComponent<Animator>();
            InitMenu();
            SetThemeColors();
        }
        
        //Initializes the menu buttons
        private void InitMenu()
        {
            exitMenu.SetActive(false);
            menuButtons.SetActive(true);
            mainMenu.SetActive(true);  
        }
        
        //Sets the colours of the menu
        private void SetThemeColors()
        {
            themeController.currentColor = themeController.custom1.graphic1;
                themeController.textColor = themeController.custom1.text1;
        }
        
        //Opens the match menu
        public void OpenMatchCanvas()
        {
            matchCanvas.SetActive(true);
        }
        
        //Opens the settings menu
        public void OpenSettingsCanvas()
        {
            settingsCanvas.SetActive(true);
        }
        
        //Opens the credits menu
        public void OpenCreditsCanvas()
        {
            creditsCanvas.SetActive(true);
        }
        
        //Closes all the menus
        public void CloseCanvas()
        {
            creditsCanvas.SetActive(false);
            settingsCanvas.SetActive(false);
            matchCanvas.SetActive(false);
            exitMenu.SetActive(false);
        }
        
        //A routine to close the menus after 0.5 seconds
        IEnumerator CloseCanvasRoutine()
        {
            yield return new WaitForSeconds(0.5f);
            CloseCanvas();
        }
        
        //Calls the routine to call the menus
        public void ReturnMenu()
        {
            StartCoroutine(CloseCanvasRoutine());
        }
        
        //Changes the display to position2 to display the menus
        public void Position2()
        {
            cameraObject.SetFloat("Animate", 1);
        }

        //Changes the display to position1 to display the main menu
        public void Position1()
        {
            cameraObject.SetFloat("Animate", 0);
        }
        
        //Quits the game
        public void QuitGame()
        {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
			 Application.Quit();
        #endif
        }
        
        //Displays the confirmation menu to confirm or decline quitting the game
        public void QuitConfirmation()
        {
            exitMenu.SetActive(true);
        }

        //Plays a sound whenever the mouse hovers over a button
        public void PlayHover()
        {
            hoverSound.Play();
        }

        //Plays a sound whenever the slider value changes
        public void PlaySFXHover()
        {
            sliderSound.Play();
        }

        //Plays a sound whenever a menu is open
        public void PlaySwoosh()
        {
            swooshSound.Play();
        }
        
        

      

      
        
        
        
        
        
        
        
        
        
        




    }
}
