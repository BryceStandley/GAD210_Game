using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuUI;
    public GameObject OptionsUI;
    public GameObject ControlsUI;
    public GameObject LevelSelectUI;
    public GameObject QuitUI;
    public GameObject BlackFade;
    public float disableDelay = 0.5f;

    private void Awake()
    {
        BlackFade.GetComponent<Animation>().Play("BlackFadeIn");
        Invoke("DisableBlackFade", disableDelay);
    }



    public void PlayGame()
    {
        SceneManager.LoadScene(2);
        LevelLoader.instance.currentLevelIndex = 2;
    }

    public void ControlOff()
    {
        OptionsUI.SetActive(true);
        ControlsUI.GetComponent<Animation>().Play("ControlsOut");
        OptionsUI.GetComponent<Animation>().Play("OptionsInControls");
        Invoke("DisableControls", disableDelay);
        
    }
    public void ControlOn()
    {
        ControlsUI.SetActive(true);
        ControlsUI.GetComponent<Animation>().Play("ControlsIn");
        OptionsUI.GetComponent<Animation>().Play("OptionsOutControls");
        Invoke("DisableOptions", disableDelay);
    }

    public void LevelSelectOn()
    {
        LevelSelectUI.SetActive(true);
        MainMenuUI.GetComponent<Animation>().Play("MainMenuOutLevelSelect");
        LevelSelectUI.GetComponent<Animation>().Play("LevelSelectIn");
        Invoke("DisableMainMenu", disableDelay);
    }

    public void LevelSelectOff()
    {
        MainMenuUI.SetActive(true);
        LevelSelectUI.GetComponent<Animation>().Play("LevelSelectOut");
        MainMenuUI.GetComponent<Animation>().Play("MainMenuInLevelSelect");
        Invoke("DisableLevelSelect", disableDelay);
    }

    public void OptionsOn()
    {
        OptionsUI.SetActive(true);
        MainMenuUI.GetComponent<Animation>().Play("MainMenuOut");
        OptionsUI.GetComponent<Animation>().Play("OptionsIn");
        Invoke("DisableMainMenu", disableDelay);
    }

    public void OptionsOff()
    {
        MainMenuUI.SetActive(true);
        OptionsUI.GetComponent<Animation>().Play("OptionsOut");
        MainMenuUI.GetComponent<Animation>().Play("MainMenuIn");
        Invoke("DisableOptions", disableDelay);
    }

    public void QuitOn()
    {
        QuitUI.SetActive(true);
        MainMenuUI.GetComponent<Animation>().Play("MainMenuOutQuit");
        QuitUI.GetComponent<Animation>().Play("QuitIn");
        Invoke("DisableMainMenu", disableDelay);
    }

    public void QuitOff()
    {
        MainMenuUI.SetActive(true);
        QuitUI.GetComponent<Animation>().Play("QuitOut");
        MainMenuUI.GetComponent<Animation>().Play("MainMenuInQuit");
        Invoke("DisableQuit", disableDelay);
    }
    private void DisableBlackFade()
    {
        BlackFade.SetActive(false);
    }
    private void DisableOptions()
    {
        OptionsUI.SetActive(false);
    }
    
    private void DisableControls()
    {
        ControlsUI.SetActive(false);
    }

    private void DisableMainMenu()
    {
        MainMenuUI.SetActive(false);
    }

    private void DisableLevelSelect()
    {
        LevelSelectUI.SetActive(false);
    }

    private void DisableQuit()
    {
        QuitUI.SetActive(false);
    }

    public void QuitGame()
    {
        BlackFade.SetActive(true);
        BlackFade.GetComponent<Animation>().Play("BlackFadeOut");
        Invoke("AppQuit", disableDelay);
    }

    private void AppQuit()
    {
        Debug.Log("App Quit");
        Application.Quit();
    }
}
