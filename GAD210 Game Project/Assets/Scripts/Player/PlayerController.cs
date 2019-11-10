using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 3f;
    public float runSpeed = 5f;
    public float turnSmoothTime = 0.12f;

    private float _turnSmoothVelocity;

    public float speedSmoothTime = 0.12f;
    private float _speedSmoothVelocity;
    private float _currentSpeed;

    private Animator _animator;
    private Transform _camera;
    private bool _inputAllowed = false;
    private Rigidbody _rigidbody;

    void Start()
    {
        _animator = transform.GetChild(0).GetComponent<Animator>();
        _camera = Camera.main.transform;
        _rigidbody = GetComponent<Rigidbody>();
        //Invoke("Enable", .5f);
    }

    public void EnableInput()
    {
        this.gameObject.GetComponent<Rigidbody>().useGravity = true;
        _inputAllowed = true;

    }

    public void DisableInput()
    {
        _inputAllowed = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_inputAllowed)
        {
            Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));//Getting user input
            Vector2 inputDir = input.normalized;

            if (inputDir != Vector2.zero)//Checking if user has given input to move player
            {
                float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + _camera.eulerAngles.y;
                transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref _turnSmoothVelocity, turnSmoothTime);//Looking towards direction with smoothing
            }

            bool running = Input.GetKey(KeyCode.LeftShift);//Check if player is holding shift

            float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;//Inline If Statement to change player speed if player is holding the run key

            _currentSpeed = Mathf.SmoothDamp(_currentSpeed, targetSpeed, ref _speedSmoothVelocity, speedSmoothTime);//Smooth transition from speeds

            //_rigidbody.MovePosition(transform.forward);
            transform.Translate(transform.forward * _currentSpeed * Time.deltaTime, Space.World);
            //transform.Translate(transform.forward * _currentSpeed, Space.World);

            float animationSpeedPercent = ((running) ? 1 : 0.5f) * inputDir.magnitude;
            _animator.SetFloat("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);

        }
    }



}
