using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class InputManager : MonoBehaviour
{

    private void OnEnable() 
    {
        _keys = new Dictionary<string, KeyCode>();

        if(PlayerPrefs.GetString("forwardKey", "na").Equals("na"))
        {
            _keys["Forward"] = KeyCode.W;
            _keys["Backward"] = KeyCode.S;
            _keys["Left"] = KeyCode.A;
            _keys["Right"] = KeyCode.D;
            _keys["Sprint"] = KeyCode.LeftShift;
            _keys["Pause"] = KeyCode.Escape;
        }
        else
        {
            _keys["Forward"] = FindSavedKey("forwardKey");
            _keys["Backward"] = FindSavedKey("backwardKey");
            _keys["Left"] = FindSavedKey("leftKey");
            _keys["Right"] = FindSavedKey("rightKey");
            _keys["Sprint"] = FindSavedKey("sprintKey");
            _keys["Pause"] = FindSavedKey("pauseKey");
        }

    }

    private KeyCode FindSavedKey(string savedKey)
    {
        KeyCode key = KeyCode.W;
        foreach(KeyCode kc in Enum.GetValues(typeof(KeyCode)))
        {
            string keyToCheck = PlayerPrefs.GetString(savedKey, "na");
            if(keyToCheck != "na")
            {
                if(keyToCheck == kc.ToString())
                {
                    key = kc;
                    break;
                }
            }
        }
        return key;
        
    }

    private Dictionary<string, KeyCode> _keys;
    public string[] GetButtonNames()
    {
        return _keys.Keys.ToArray();
    }

    public bool GetButtonDown(string buttonName)
    {
        if(_keys.ContainsKey(buttonName) == false)
        {
            Debug.LogError("InputManager::GetButtonDown -- No button named: " +buttonName);
            return false;
        }

        return Input.GetKeyDown(_keys[buttonName]);
    }

    public string GetKeyNameForButton(string buttonName)
    {
                if(_keys.ContainsKey(buttonName) == false)
        {
            Debug.LogError("InputManager::GetKeyNameForButton -- No button named: " +buttonName);
            return "N/A";
        }
        return _keys[buttonName].ToString();
    }

    public void SetButtonForKey(string buttonName, KeyCode keyCode)
    {
        _keys[buttonName] = keyCode;
    }
}
