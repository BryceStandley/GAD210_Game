﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool cameraEnable = true;
    public bool rotateCamera     =   true;
    public float rotationSpeed   =   5.0f;

    public Transform cameraTarget;

    public float _cameraOffset = 50.0f;
    public Vector2 pitchMinMax = new Vector2(-40, 85);
    public float rotationSmoothTime = 0.12f;
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

    private PlayerManager _playerManager;
    private float _yaw;
    private float _pitch;
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _playerManager = FindObjectOfType<PlayerManager>();
        cameraTarget = _playerManager.player.transform;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(rotateCamera)
            {
                rotateCamera = false;
            }
            else if(!rotateCamera)
            {
                rotateCamera = true;
            }
        }

    }

    private void LateUpdate()
    {
       if(rotateCamera)
        {
            _yaw += Input.GetAxis("Mouse X") * rotationSpeed;
            _pitch -= Input.GetAxis("Mouse Y") * rotationSpeed;
            _pitch = Mathf.Clamp(_pitch, pitchMinMax.x, pitchMinMax.y);

            currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(_pitch, _yaw), ref rotationSmoothVelocity, rotationSmoothTime);

            transform.eulerAngles = currentRotation;

            transform.position = cameraTarget.position - transform.forward * _cameraOffset;


            /*transform.RotateAround(_pointToRotateAround.position, transform.right, -Input.GetAxis("Mouse Y") * rotationSpeed);
            transform.RotateAround(_pointToRotateAround.position, transform.up, -Input.GetAxis("Mouse X") * rotationSpeed);
            transform.LookAt(_pointToRotateAround); */
        }
    }

}
