using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public int currentLevelIndex;

    public void LoadMidLoader()
    {
        SceneManager.LoadScene("midSceneLoader");
    }
    public void ReloadCurrentLevel()
    {
        
        SceneManager.LoadScene(currentLevelIndex + 1);
    }

}
