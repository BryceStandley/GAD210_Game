using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

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
        //reset score

        /*GameObject player = GameObject.FindGameObjectWithTag("Player");
        Camera.main.GetComponent<CameraController>().cameraTarget = this.gameObject.transform;
        Destroy(player);
        GameObject newPlayer = Object.Instantiate(playerPrefab) as GameObject;
        newPlayer.transform.position = this.transform.position;
        _playerManager = FindObjectOfType<PlayerManager>();
        _playerManager.player = newPlayer;
        Camera.main.GetComponent<CameraController>().cameraTarget = newPlayer.transform;
        // function to reset any other positions*/

        /*GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            player.GetComponent<Rigidbody>().isKinematic = true;
            
            player.transform.position = this.transform.position;
            player.GetComponent<Rigidbody>().isKinematic = false;
            Invoke("UpdatePlayerPos", 5f);
        }*/

    }

    private void UpdatePlayerPos()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
    
}
