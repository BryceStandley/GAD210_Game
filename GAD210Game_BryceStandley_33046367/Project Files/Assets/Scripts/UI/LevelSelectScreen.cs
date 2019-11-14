using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectScreen : MonoBehaviour
{
    public Button tutorialButton;
    public Button level01Button;
    public Button level02Button;
    private void Awake() {
        if(PlayerPrefs.GetInt("tutorial", 0) == 1)
        {
            tutorialButton.interactable = true;

            if (PlayerPrefs.GetInt("level01", 0) == 1)
            {
                level01Button.interactable = true;

                if (PlayerPrefs.GetInt("level02", 0) == 1)
                {
                    level02Button.interactable = true;
                }
            }
        }
        else
        {
            tutorialButton.interactable = true;
            level01Button.interactable = false;
            level02Button.interactable = false;
        }

    }

    public void PlayLevel(int levelNum)
    {
        if(levelNum == 0)
        {
            SceneManager.LoadScene("Loading");
        }
        else if(levelNum == 1)
        {
            SceneManager.LoadScene(3);
        }
        else if(levelNum == 2)
        {
            SceneManager.LoadScene(4);
        }
    }
}
