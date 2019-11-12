using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _eggScore = 0;
    private int _starScore = 0;


    public void IncrementEgg()
    {
        _eggScore++;
    }

    public void IncrementStar()
    {
        _starScore++;
    }

    public int GetEgg()
    {
        return _eggScore;
    }

    public int GetStar()
    {
        return _starScore;
    }

    public void ResetScore()
    {
       _eggScore = 0;
       _starScore = 0;
    }
}
