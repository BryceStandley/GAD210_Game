using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class GameSettingsManager : MonoBehaviour
{
    private float _fovValue = 60f;
    private float _volumeValue = 1f;
    private float _sensitivityValue = 1f;
    private bool _isFullScreen = false;
    private bool _isWindowed = true;
    private bool _isBorderless = false;

    public AudioMixer mainMixer;
    public Toggle fullToggle, winToggle, bordToggle;

    private void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
    }

    public void FOVSetting(float val)
    {
        _fovValue = val;
        SetFOV();
    }

    public void VolumeSetting(float val)
    {
        _volumeValue = val;
        SetVolume();
    }

    public void SensitivitySetting(float val)
    {
        _sensitivityValue = val;
        SetSensitivity();
    }

    public void SetFullScreen()
    {
        if(fullToggle.isOn)
        {
            _isFullScreen = true;
            _isBorderless = false;
            _isWindowed = false;
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
            DisableToggles();
        }
    }

    public void SetWindowed()
    {
        if(winToggle.isOn)
        {
            _isWindowed = true;
            _isFullScreen = false;
            _isBorderless = false;
            Screen.fullScreenMode = FullScreenMode.Windowed;
            DisableToggles();
        }
    }

    public void SetBorderless()
    {
        if(bordToggle.isOn)
        {
            _isBorderless = true;
            _isWindowed = false;
            _isFullScreen = false;
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
            DisableToggles();
        }
    }

    private void DisableToggles()
    {
       if(_isFullScreen)
        {
            winToggle.isOn = false;
            bordToggle.isOn = false;
        }
       else if(_isBorderless)
        {
            fullToggle.isOn = false;
            winToggle.isOn = false;
        }
       else if(_isWindowed)
        {
            fullToggle.isOn = false;
            bordToggle.isOn = false;
        }
    }

    public void SetFOV()
    {
        Camera.main.fieldOfView = _fovValue;
    }

    public void SetVolume()
    {
        mainMixer.SetFloat("GameVol", Mathf.Log10(_volumeValue) * 20);
    }

    private void SetSensitivity()
    {
        CameraController _camController = FindObjectOfType<CameraController>();
        _camController.rotationSpeed = _sensitivityValue;
    }



}
