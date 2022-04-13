using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace SlimUI.ModernMenu
{
    public class MainMenuNew : MonoBehaviour
    {
        Animator cameraObject;
        
        [Header("Loaded Scene")] 
        public string sceneName;
        
        public enum Theme {custom1, custom2, custom3};
        [Header("Theme Settings")]
        public Theme theme;
        int themeIndex;
        public FlexibleUIData themeController;

        [Header("Panels")] 
        public GameObject mainCanvas;
        public GameObject panelControls;
        public GameObject panelVideo;
        public GameObject panelGame;
        public GameObject panelCredits;


        [Header("SFX")] 
        public AudioSource hoverSound;
        public AudioSource sliderSound;
        public AudioSource swooshSound;

        // campaign button sub menu
        [Header("Menus")]
        public GameObject mainMenu;
        public GameObject firstMenu;
        public GameObject playMenu;
        public GameObject exitMenu;
        public GameObject extrasMenu;

        // highlights
        [Header("Highlight Effects")] 
        public GameObject lineGame;
        public GameObject lineVideo;
        public GameObject lineControls;
        
        [Header("LOADING SCREEN")]
        public GameObject loadingMenu;
        public Slider loadBar;
        public TMP_Text finishedLoadingText;

        [Header("CANVAS")] 
        public GameObject creditsCanvas;
        public GameObject settingsCanvas;
        public GameObject matchCanvas;

        void Start()
        {
            cameraObject = transform.GetComponent<Animator>();

            playMenu.SetActive(false);
            exitMenu.SetActive(false);
            firstMenu.SetActive(true);
            mainMenu.SetActive(true);

            SetThemeColors();
        }
        

        void SetThemeColors(){
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
        
        public void OpenCreditsCanvas()
        {
            creditsCanvas.SetActive(true);
        }
        
        public void OpenSettingsCanvas()
        {
            settingsCanvas.SetActive(true);
        }
        
        public void OpenMatchCanvas()
        {
            matchCanvas.SetActive(true);
        }
        

        public void CloseCanvas()
        {
            creditsCanvas.SetActive(false);
            settingsCanvas.SetActive(false);
            matchCanvas.SetActive(false);
        }


        public void ReturnMenu()
        {
            exitMenu.SetActive(false);
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

        void DisablePanels()
        {
            panelControls.SetActive(false);
            panelVideo.SetActive(false);
            panelGame.SetActive(false);
            lineGame.SetActive(false);
            lineControls.SetActive(false);
            lineVideo.SetActive(false);
        }

        public void GamePanel()
        {
            DisablePanels();
            panelGame.SetActive(true);
            lineGame.SetActive(true);
        }

        public void VideoPanel()
        {
            DisablePanels();
            panelVideo.SetActive(true);
            lineVideo.SetActive(true);
        }

        public void ControlsPanel()
        {
            DisablePanels();
            panelControls.SetActive(true);
            lineControls.SetActive(true);
        }

        public void CreditsPanel()
        {
            panelCredits.SetActive(true);
        }


        public void PlayHover()
        {
            hoverSound.Play();
        }

        public void PlaySFXHover()
        {
            sliderSound.Play();
        }

        public void PlaySwoosh()
        {
            swooshSound.Play();
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

        
        
        
        public void Play()
        {
            StartCoroutine(LoadAsynchronously(sceneName));
        }

        
        
        IEnumerator LoadAsynchronously(string sceneName)
        {
            // scene name is just the name of the current scene being loaded
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
            operation.allowSceneActivation = false;
            mainCanvas.SetActive(false);
            loadingMenu.SetActive(true);

            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / .9f);
                loadBar.value = progress;

                if (operation.progress >= 0.9f)
                {
                    finishedLoadingText.gameObject.SetActive(true);
                    operation.allowSceneActivation = true;
                }
                yield return null;
            }
        }
    }
}