using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.ThirdPerson;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject scores;

    private bool _IsPaused;

    private PlayerInputController _player;
    private bool _inputAllowed = false;
    private bool _hasBeenPressed = false;

    private GameSettingsManager _gSM;
    private void Start() 
    {
        _player = FindObjectOfType<PlayerInputController>();
        _gSM = FindObjectOfType<GameSettingsManager>(); 
    }

    public void AllowInput()
    {
        _inputAllowed = true;
    }

    public void DisallowInput()
    {
        _inputAllowed = false;
    }
    void Update()
    {
        if(_inputAllowed)
        {
            if(Input.GetAxisRaw("Cancel") > 0  && !_IsPaused)
            {
                if(!_hasBeenPressed)
                {
                    PauseEnable();
                    _hasBeenPressed = true;
                }
                
            }
            else if(Input.GetAxisRaw("Cancel") > 0 && _IsPaused)
            {
                if(!_hasBeenPressed)
                {
                    PauseDisable();
                    _hasBeenPressed = true;
                }

            }
            else
            {
                _hasBeenPressed = false;
            }
        }
    }

    private void PauseEnable()
    {
        _IsPaused = true;
        _player.Disable();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pauseMenu.SetActive(true);
        scores.SetActive(false);
        Time.timeScale = 0;
    }

    public void PauseDisable()
    {
        _IsPaused = false;
        _player.Enable();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        scores.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        SaveGame();
        Application.Quit();
    }

    private void SaveGame()
    {
        ScoreCounter score = FindObjectOfType<ScoreCounter>();
        string levelName = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetInt("levelName", 1);
        PlayerPrefs.SetInt(levelName +"Stars", score.GetStar());
        PlayerPrefs.SetInt(levelName +"Eggs", score.GetEgg());
    }
}
