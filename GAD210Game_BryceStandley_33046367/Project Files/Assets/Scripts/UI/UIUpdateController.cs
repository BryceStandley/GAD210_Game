using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIUpdateController : MonoBehaviour
{
    public TextMeshProUGUI eggText;
    public TextMeshProUGUI levelCompleteEggText;
    public TextMeshProUGUI starText;
    public TextMeshProUGUI levelCompleteStarText;
    public ScoreCounter scoreCounter;

    public void UpdateEggUI()
    {
        scoreCounter.IncrementEgg();
        eggText.text = scoreCounter.GetEgg().ToString();
        levelCompleteEggText.text = scoreCounter.GetEgg().ToString();
    }

    public void UpdateStarUI()
    {
        scoreCounter.IncrementStar();
        starText.text = scoreCounter.GetStar().ToString();
        levelCompleteStarText.text = scoreCounter.GetStar().ToString();
    }


}
