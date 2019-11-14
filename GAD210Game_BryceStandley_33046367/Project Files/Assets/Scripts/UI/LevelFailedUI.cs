using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFailedUI : MonoBehaviour
{
    public Animation BlackFade;
    public LevelResetScreen levelResetScreen;
    public PlayerSpawnPoint playerSpawnPoint;

    public void ResetLevel()
    {
        
        levelResetScreen.SetTimeScaleToOne();
        levelResetScreen.PlayScreenAnimationOut();
        BlackFade.gameObject.SetActive(true);
        BlackFade.Play("BlackFadeIn");
        playerSpawnPoint.ResetLevel();


        /*
        levelResetScreen.SetTimeScaleToOne();
        levelResetScreen.PlayScreenAnimationOut();
        BlackFade.gameObject.SetActive(true);
        BlackFade.Play();
        LevelLoader.instance.currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        LevelLoader.instance.LoadMidLoader();
        */
    }

    public void MainMenu()
    {
        levelResetScreen.SetTimeScaleToOne();
        levelResetScreen.PlayScreenAnimationOut();
        BlackFade.gameObject.SetActive(true);
        BlackFade.Play("BlackFadeIn");
        SceneManager.LoadScene("mainMenu");
    }
}
