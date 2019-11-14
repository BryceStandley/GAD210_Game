using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{

    public GameObject blackFade;
    public GameObject levelEndScreen;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            blackFade.SetActive(true);
            blackFade.GetComponent<BlackFadeDisableEnable>().isLevelEnd = true;
            blackFade.GetComponent<Animation>().Play("BlackFadeOut");
            levelEndScreen.SetActive(true);
            GetComponent<AudioSource>().Play();
            FindObjectOfType<PlayerInputController>().Disable(); // disable player input to player character
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
    }


    public void LoadNextLevel()
    {
        string levelName = SceneManager.GetActiveScene().name;
        ScoreCounter scoreCounter = FindObjectOfType<ScoreCounter>();
        PlayerPrefs.SetInt(levelName, 1);
        PlayerPrefs.SetInt(levelName+"Stars", scoreCounter.GetStar());
        PlayerPrefs.SetInt(levelName+"Eggs", scoreCounter.GetEgg());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Level03End()
    {
        string levelName = SceneManager.GetActiveScene().name;
        ScoreCounter scoreCounter = FindObjectOfType<ScoreCounter>();
        PlayerPrefs.SetInt(levelName, 1);
        PlayerPrefs.SetInt(levelName+"Stars", scoreCounter.GetStar());
        PlayerPrefs.SetInt(levelName+"Eggs", scoreCounter.GetEgg());
        SceneManager.LoadScene(0);
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void LoadMainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }
}
