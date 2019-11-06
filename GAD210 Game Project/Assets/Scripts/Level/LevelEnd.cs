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
            blackFade.GetComponent<Animation>().Play("BlackFadeOut");
            levelEndScreen.SetActive(true);
        }
    }


    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
