using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    private void Start() {
        FindObjectOfType<PlayerController>().DisableInput();
    }
}
