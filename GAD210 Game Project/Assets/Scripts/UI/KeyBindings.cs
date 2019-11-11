using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class KeyBindings : MonoBehaviour
{
    private InputManager inputManager;

    public GameObject keyUIPrefab;
    public GameObject keyUIParent;

    private void Start() 
    {
        inputManager = FindObjectOfType<InputManager>();

        _buttonToLabel = new Dictionary<string, TextMeshProUGUI>();

        string[] buttonNames = inputManager.GetButtonNames();

        for(int i = 0; i < buttonNames.Length; i++)
        {
            string bn = buttonNames[i];
            GameObject go = (GameObject)Instantiate(keyUIPrefab);
            go.transform.SetParent(keyUIParent.transform);
            go.transform.localScale = Vector3.one;

            go.GetComponent<TextMeshProUGUI>().text = bn;

            TextMeshProUGUI keyText =  go.transform.Find("Button/keyName").GetComponent<TextMeshProUGUI>();
            keyText.text = inputManager.GetKeyNameForButton(bn);
            _buttonToLabel[bn] = keyText;

            Button keyButton = go.transform.Find("Button").GetComponent<Button>();
            keyButton.onClick.AddListener( () => {StartRebindFor(bn); } );
        }
    }

    void Update()
    {
        if(_buttonToRebind != null)
        {
            if(Input.anyKeyDown)
            {
                foreach(KeyCode kc in Enum.GetValues(typeof(KeyCode)))
                {
                    if(Input.GetKeyDown(kc))
                    {
                        inputManager.SetButtonForKey(_buttonToRebind, kc);
                        _buttonToLabel[_buttonToRebind].text = kc.ToString();
                        _buttonToRebind = null;
                        break;
                    }
                }
            }
        }
    }



    private string _buttonToRebind;
    private Dictionary<string, TextMeshProUGUI> _buttonToLabel;
    private void StartRebindFor(string buttonName)
    {
        _buttonToRebind = buttonName;
    }

}
