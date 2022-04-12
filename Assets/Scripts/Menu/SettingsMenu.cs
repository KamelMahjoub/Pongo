using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    [Header("Panels")]
    public GameObject panelSettings;
    public GameObject panelControls;
    public GameObject panelPowerups;
 
    [Header("Highlight Effects")] 
    public GameObject lineSettings;
    public GameObject lineControls;
    public GameObject linePowerups;
    
    
    public void DisablePanels()
    {
        panelSettings.SetActive(false);
        panelControls.SetActive(false);
        panelPowerups.SetActive(false);
    }

    public void DisableLines()
    {
        lineSettings.SetActive(false);
        lineControls.SetActive(false);
        linePowerups.SetActive(false);
    }

    public void DisableMenu()
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
    
    
    
    
 
}
