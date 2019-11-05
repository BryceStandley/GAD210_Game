using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReLoader : MonoBehaviour
{
    public float reloadTime = 20f;
    private void Start()
    {
        Resources.UnloadUnusedAssets();
        Invoke("ReLoad", reloadTime);
    }

    private void ReLoad()
    {
        
        LevelLoader.instance.ReloadCurrentLevel();
    }
}
