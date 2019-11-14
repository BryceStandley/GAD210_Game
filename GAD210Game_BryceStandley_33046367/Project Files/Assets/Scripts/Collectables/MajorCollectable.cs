using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MajorCollectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            transform.parent.GetChild(1).GetComponent<ParticleSystem>().Play();
            GetComponent<MeshRenderer>().enabled = false;

            UIUpdateController UI = FindObjectOfType<UIUpdateController>();
            UI.UpdateStarUI();

            SoundController sound = FindObjectOfType<SoundController>();
            sound.PlayStarSound();

            Invoke("DestryStar", 1f);
        }
    }

    private void DestryStar()
    {
        Destroy(this.transform.parent.gameObject);
    }
}
