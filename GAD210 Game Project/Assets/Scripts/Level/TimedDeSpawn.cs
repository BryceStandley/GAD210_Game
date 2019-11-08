using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDeSpawn : MonoBehaviour
{
    public float destryTime = 5f;
    private void Start() {
        Invoke("DestroyItem", destryTime);  
    }

    private void DestroyItem()
    {
        Destroy(this.gameObject);
    }
}
