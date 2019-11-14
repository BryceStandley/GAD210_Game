using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackFadeDisableEnable : MonoBehaviour
{
    private float _fadeDisable = 0.5f;
    public GameObject blackSolid;
    public bool isLevelEnd = false;

    private void Start() 
    {
        if(isLevelEnd)
        {
            Invoke("DisableFade", _fadeDisable);
        }
    }

    private void DisableFade()
    {
        blackSolid.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
