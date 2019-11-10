using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelSelectScores : MonoBehaviour
{
    public bool egg = false;
    public bool star = true;
    public string levelName;
    private void Awake() 
    {
        if(egg)
        {
            int score = PlayerPrefs.GetInt(levelName +"Eggs", 0);
            GetComponent<TextMeshProUGUI>().text = score.ToString();
        } 
        else
        {
            int score = PlayerPrefs.GetInt(levelName +"Stars", 0);
            GetComponent<TextMeshProUGUI>().text = score.ToString(); 
        }
    }
}
