using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip eggCollectionSound;
    public AudioClip starCollectionSound;

    public void PlayEggSound()
    {
        GetComponent<AudioSource>().PlayOneShot(eggCollectionSound);
    }
    public void PlayStarSound()
    {
        GetComponent<AudioSource>().PlayOneShot(starCollectionSound);
    }
}
