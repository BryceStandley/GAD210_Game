using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    // Start is called before the first frame update
    public void Disable() 
    {
        FindObjectOfType<PlayerController>().DisableInput();
    }

    public void Enable()
    {
        FindObjectOfType<PlayerController>().EnableInput();
    }
}
