using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public  PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }


    public GameObject player;
}
