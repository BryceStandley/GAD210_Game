using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerInputController : MonoBehaviour
{
    // Start is called before the first frame update
    public void Disable() 
    {
        FindObjectOfType<ThirdPersonUserControl>().DisableInput();
    }

    public void Enable()
    {
        FindObjectOfType<ThirdPersonUserControl>().EnableInput();
    }
}
