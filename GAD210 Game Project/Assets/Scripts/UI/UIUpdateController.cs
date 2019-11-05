using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIUpdateController : MonoBehaviour
{
    public TextMeshProUGUI eggText;
    public TextMeshProUGUI starText;
    public ScoreCounter scoreCounter;

    public void UpdateEggUI()
    {
        scoreCounter.IncrementEgg();
        eggText.text = scoreCounter.GetEgg().ToString();
    }

    public void UpdateStarUI()
    {
        scoreCounter.IncrementStar();
        starText.text = scoreCounter.GetStar().ToString();
    }


}
