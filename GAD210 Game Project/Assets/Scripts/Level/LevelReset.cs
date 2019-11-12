using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReset : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject levelFailedUI;
    public GameObject scoreUI;
    public GameObject blackFade;

    private PlayerInputController _playerInput;
    private ScoreCounter _scoreCounter;

    private void Awake() 
    {
        _playerInput = FindObjectOfType<PlayerInputController>();
        _scoreCounter = FindObjectOfType<ScoreCounter>();
    }

    private void OnTriggerEnter(Collider col) 
    {
        if(col.CompareTag("Player"))
        {
            //blackFade.SetActive(true);
            col.gameObject.transform.position = spawnPoint.transform.position;
            Camera.main.GetComponent<CameraController>().rotateCamera = false;
            _playerInput.Disable();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            levelFailedUI.SetActive(true);
            scoreUI.SetActive(false);


        //animate ui
        }
    }

    public void ResetLevelButton()
    {
        //blackFade.GetComponent<Animation>().Play("BlackFadeOut");
        //levelFailedUI.GetComponent<Animation>().Play("FailedScreenAnimOut");
        _playerInput.Enable();
        Camera.main.GetComponent<CameraController>().rotateCamera = true;
        _scoreCounter.ResetScore();
        scoreUI.SetActive(true);
        string levelName = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetInt(levelName, 1);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        levelFailedUI.SetActive(false);
        //Invoke("DisableUI", 1.2f);
    }

    private void DisableUI()
    {
        //blackFade.SetActive(false);
        levelFailedUI.SetActive(false);
    }
}
