using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    public GameObject playerPrefab;
    private PlayerManager _playerManager;
    private void Awake()
    {
        GameObject player = Object.Instantiate(playerPrefab) as GameObject;
        player.transform.position = this.transform.position;
        _playerManager = FindObjectOfType<PlayerManager>();
        _playerManager.player = player;
    }

    public void ResetLevel()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Camera.main.GetComponent<CameraController>().cameraTarget = this.gameObject.transform;
        Destroy(player);
        GameObject newPlayer = Object.Instantiate(playerPrefab) as GameObject;
        newPlayer.transform.position = this.transform.position;
        _playerManager = FindObjectOfType<PlayerManager>();
        _playerManager.player = newPlayer;
        Camera.main.GetComponent<CameraController>().cameraTarget = newPlayer.transform;
        // function to reset any other positions

    }
    
}
