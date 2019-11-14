using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReset : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject levelFailedUI;
    public GameObject scoreUI;

    private PlayerInputController _playerInput;
    private ScoreCounter _scoreCounter;

    private PauseGame _pauseGame;
    private GameObject _player;

    private void Awake() 
    {
        _playerInput = FindObjectOfType<PlayerInputController>();
        _scoreCounter = FindObjectOfType<ScoreCounter>();
        _pauseGame = FindObjectOfType<PauseGame>();
        _player = GameObject.FindGameObjectWithTag("Player");

    }

    private void OnTriggerEnter(Collider col) 
    {
        if(col.CompareTag("Player"))
        {
            col.gameObject.transform.position = spawnPoint.transform.position;
            Camera.main.GetComponent<CameraController>().rotateCamera = false;
            _playerInput.Disable();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            levelFailedUI.SetActive(true);
            scoreUI.SetActive(false);
            _pauseGame.DisallowInput();


        //animate ui
        }
    }

    public void EnemyReset()
    {
            _player.gameObject.transform.position = spawnPoint.transform.position;
            Camera.main.GetComponent<CameraController>().rotateCamera = false;
            _playerInput.Disable();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            levelFailedUI.SetActive(true);
            scoreUI.SetActive(false);
            _pauseGame.DisallowInput();
    }

    public void ResetLevelButton()
    {
        _playerInput.Enable();
        Camera.main.GetComponent<CameraController>().rotateCamera = true;
        _scoreCounter.ResetScore();
        scoreUI.SetActive(true);
        string levelName = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetInt(levelName, 1);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        levelFailedUI.SetActive(false);
        _pauseGame.AllowInput();
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0); //load main menu on click
    }
}
