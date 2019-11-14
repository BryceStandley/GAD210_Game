using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelResetScreen : MonoBehaviour
{
    public GameObject levelFailedUI;
    private void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            levelFailedUI.SetActive(true);
            PlayScreenAnimationIn();
            //mute all game audio
            Invoke("SetTimeScaleToZero", 1.2f);

        }
    }

    public void EnemyReset()
    {
        levelFailedUI.SetActive(true);
        PlayScreenAnimationIn();
        //mute all game audio
        Invoke("SetTimeScaleToZero", 1.2f);
    }

    private void SetTimeScaleToZero()
    {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
    }

    public void SetTimeScaleToOne()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = 1;
    }

    private void PlayScreenAnimationIn()
    {
        levelFailedUI.GetComponent<Animation>().Play("FailScreenAnimIn");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayScreenAnimationOut()
    {
        levelFailedUI.GetComponent<Animation>().Play("FailScreenAnimOut");
    }
}
