using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackFadeDisableEnable : MonoBehaviour
{
    private float _fadeDisable = 0.5f;

    private void Start() 
    {
        Invoke("DisableFade", _fadeDisable);
    }

    private void DisableFade()
    {
        this.gameObject.SetActive(false);
    }
}
