using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public  GameObject destryVersion;
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            Instantiate(destryVersion, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
