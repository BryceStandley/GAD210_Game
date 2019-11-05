using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinorCollectable : MonoBehaviour
{

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            transform.parent.GetChild(1).GetComponent<ParticleSystem>().Play();
            GetComponent<MeshRenderer>().enabled = false;

            UIUpdateController UI = FindObjectOfType<UIUpdateController>();
            UI.UpdateEggUI();

            SoundController sound = FindObjectOfType<SoundController>();
            sound.PlayEggSound();

            Invoke("DestryEgg", 1f);
        }
    }

    private void DestryEgg()
    {
        Destroy(this.transform.parent.gameObject);
    }

}
