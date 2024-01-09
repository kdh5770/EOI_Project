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

    [Header("카메라 관련 변수")]
    private const float _threshold = 0.01f;
    public bool LockCameraPosition = false;
    private float _cinemachineTargetYaw;
    private float _cinemachineTargetPitch;
    public float TopClamp = 70f;
    public float BottomClamp = -30f;
    public GameObject CinemachineCameraTarget;



    [Header("플레이어 스탯")]
    public int P_Hp=100;
    public float MoveSpeed = 2.0f; // 기본속도
    public float SprintSpeed = 5.3f; // 뛰는속도


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

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    private void LateUpdate()
    {
        CameraRotation();
    }

    private void Move()
    {
        float targetSpeed = _input.sprint ? SprintSpeed : MoveSpeed;
        if (_input.move == Vector2.zero)
        {
            targetSpeed = 0f;
        }

        Vector3 movement = new Vector3(_input.move.x, 0f, _input.move.y);
        Vector3 velocity = movement * targetSpeed;
        _rigidbody.velocity = new Vector3(velocity.x, _rigidbody.velocity.y, velocity.z);
        if (_input.sprint)
        {
            _animator.SetFloat("Speed", targetSpeed);
        }
        else
            _animator.SetFloat("Speed", targetSpeed);
    }

    void CameraRotation()
    {
        if(_input.look.sqrMagnitude>=_threshold&&!LockCameraPosition)
        {
            float deltaTimeMultiplier = IsCurrentDeviceMouse ? 1.0f : Time.deltaTime;

            _cinemachineTargetYaw += _input.look.x * deltaTimeMultiplier;
            _cinemachineTargetPitch += _input.look.y * deltaTimeMultiplier;

            _cinemachineTargetYaw = ClampAngle(_cinemachineTargetYaw, float.MinValue, float.MaxValue);
            _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);


            CinemachineCameraTarget.transform.rotation = Quaternion.Euler(_cinemachineTargetPitch + 0.0f, _cinemachineTargetYaw, 0.0f);
        }
    }

    private static float ClampAngle(float IfAngle, float IfMin, float IfMax)
    {
        if (IfAngle < -360f) IfAngle += 360f;
        if (IfAngle > 360f) IfAngle -= 360f;

        return Mathf.Clamp(IfAngle, IfMin, IfMax);
    }
}