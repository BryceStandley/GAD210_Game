using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    private void Start() 
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex +1;
        //SceneManager.LoadScene("level01");
        SceneManager.LoadScene(nextScene);
    }
}
