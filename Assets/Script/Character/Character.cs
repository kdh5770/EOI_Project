using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

#if ENABLE_INPUT_SYSTEM
[RequireComponent(typeof(PlayerInput))]
#endif
public class Character : MonoBehaviour
{
    private CharacterInputSystem _input;
    private Rigidbody _rigidbody;
#if ENABLE_INPUT_SYSTEM
    private PlayerInput _playerinput;
#endif
    private Animator _animator;
    Camera _mainCamera;
    public Vector2 input;

    [Header("플레이어 스탯")]
    public int P_Hp=100;
    public float MoveSpeed = 2.0f; // 기본속도
    public float SprintSpeed = 5.3f; // 뛰는속도

    [Header("카메라 관련 변수")]
    public GameObject CinemachineCameraTarget;
    private float _cinemachineTargetYaw;
    private float _cinemachineTargetPitch;
    public float TopClamp = 70f;
    public float BottomClamp = -30f;
    public float CameraAngleOverride = 0.0f;
    private const float _threshold = 0.01f;
    public bool LockCameraPosition = false;

    // player
    private float _animationBlend;
    private float _speed;
    private float SpeedChangeRate = 10.0f;
    private float _targetRotation = 0.0f;
    private float RotationSmoothTime = 0.12f;
    private float _rotationVelocity;
    private float _terminalVelocity = 53.0f;
#if ENABLE_INPUT_SYSTEM
    private bool IsCurrentDeviceMouse
    {
        get
        {
            return _playerinput.currentControlScheme == "PC";
#else
            return false;
#endif
        }
    }

    void Start()
    {
        _input = GetComponent<CharacterInputSystem>();
        _playerinput = GetComponent<PlayerInput>();
        _animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _mainCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Move(); // 움직임
    }

    private void LateUpdate()
    {
        CameraRotation(); // 카메라 회전
    }

    private void Move()
    {
        // 첫번째 이동
        /*        float targetSpeed = _input.sprint ? SprintSpeed : MoveSpeed; // input 참 일때 sprintspeed, 거짓일 때 movespeed

                if (_input.move == Vector2.zero) // wasd 입력값 없을때 vector값 제로
                {
                    targetSpeed = 0f;
                }
                Vector3 movement = new Vector3(_input.move.x, 0f, _input.move.y).normalized;
                Vector3 velocity = movement * targetSpeed;

                _rigidbody.velocity = new Vector3(velocity.x, _rigidbody.velocity.y, velocity.z);

                float speedOffset = 0.1f;
                float inputMagnitude = _input.analogMovement ? _input.move.magnitude : 1f;

                float currentHorizontalSpeed = new Vector3(_rigidbody.velocity.x, 0.0f, _rigidbody.velocity.z).magnitude;

                if (currentHorizontalSpeed < targetSpeed - speedOffset || currentHorizontalSpeed > targetSpeed + speedOffset)
                {
                    _speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed * inputMagnitude, Time.deltaTime * SpeedChangeRate);

                    _speed = Mathf.Round(_speed * 1000f) / 1000f;
                }

                else
                    _speed = targetSpeed;

                _animationBlend = Mathf.Lerp(currentHorizontalSpeed, targetSpeed * inputMagnitude, Time.deltaTime * SpeedChangeRate);

                if (_animationBlend < 0.01f)
                {
                    _animationBlend = 0f;
                }

                Vector3 inputDirection = new Vector3(_input.move.x, 0.0f, _input.move.y).normalized;

                if(_input.move!=Vector2.zero)
                {
                    _targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + _mainCamera.transform.eulerAngles.y;
                    float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity, RotationSmoothTime);

                    transform.rotation = Quaternion.Euler(0.0f, _targetRotation, 0.0f);
                }

                Vector3 targetDirection = Quaternion.Euler(0.0f, _targetRotation, 0.0f) * Vector3.forward;
        */

        // 2번째 방법
        float targetSpeed = _input.sprint ? SprintSpeed : MoveSpeed; // input 참 일때 sprintspeed, 거짓일 때 movespeed
        Vector3 inputDirection = new Vector3(_input.move.x, 0.0f, _input.move.y).normalized;

        if (_input.move == Vector2.zero)
        {
            targetSpeed = 0f;
        }


        if (inputDirection != Vector3.zero)
        {
            _targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg;
            float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity, RotationSmoothTime);
            transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
        }

        //Vector3 moveDirection = Quaternion.Euler(0.0f, _targetRotation, 0.0f) * Vector3.forward;
        
        
        _rigidbody.velocity = transform.forward * (targetSpeed * inputDirection.magnitude);
        

        // 걷기/뛰기 애니메이션 출력
        _animator.SetFloat("Speed", targetSpeed);   
    }

    private void CameraRotation()
    {
        // if there is an input and camera position is not fixed
        if (_input.look.sqrMagnitude >= _threshold && !LockCameraPosition)
        {
            //Don't multiply mouse input by Time.deltaTime;
            float deltaTimeMultiplier = IsCurrentDeviceMouse ? 1.0f : Time.deltaTime;

            _cinemachineTargetYaw += _input.look.x * deltaTimeMultiplier;
            _cinemachineTargetPitch += _input.look.y * deltaTimeMultiplier;
        }

        // clamp our rotations so our values are limited 360 degrees
        _cinemachineTargetYaw = ClampAngle(_cinemachineTargetYaw, float.MinValue, float.MaxValue);
        _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

        // Cinemachine will follow this target
        CinemachineCameraTarget.transform.rotation = Quaternion.Euler(_cinemachineTargetPitch + CameraAngleOverride, _cinemachineTargetYaw, 0.0f);
    }


    private static float ClampAngle(float IfAngle, float IfMin, float IfMax)
    {
        if (IfAngle < -360f) IfAngle += 360f;
        if (IfAngle > 360f) IfAngle -= 360f;
        return Mathf.Clamp(IfAngle, IfMin, IfMax);
    }
}