using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]    private bool _rotateCamera     =   true;
    [SerializeField]    private float _rotationSpeed   =   5.0f;

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
            if(_rotateCamera)
            {
                _rotateCamera = false;
            }
            else if(!_rotateCamera)
            {
                _rotateCamera = true;
            }
        }
    }

    private void LateUpdate()
    {
       if(_rotateCamera)
        {
            _yaw += Input.GetAxis("Mouse X") * _rotationSpeed;
            _pitch -= Input.GetAxis("Mouse Y") * _rotationSpeed;
            _pitch = Mathf.Clamp(_pitch, pitchMinMax.x, pitchMinMax.y);

            currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(_pitch, _yaw), ref rotationSmoothVelocity, rotationSmoothTime);

            transform.eulerAngles = currentRotation;

            transform.position = cameraTarget.position - transform.forward * _cameraOffset;


            /*transform.RotateAround(_pointToRotateAround.position, transform.right, -Input.GetAxis("Mouse Y") * _rotationSpeed);
            transform.RotateAround(_pointToRotateAround.position, transform.up, -Input.GetAxis("Mouse X") * _rotationSpeed);
            transform.LookAt(_pointToRotateAround); */
        }
    }

}
