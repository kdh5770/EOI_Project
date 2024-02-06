using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using Cinemachine;

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

    [Header("�÷��̾� ����")]
    public int Cur_P_Hp=100; // �÷��̾� ���� ü��
    public int Max_P_Hp = 100; // �÷��̾� �ִ� ü��
    public int Cur_P_Armor; // �÷��̾� ���� �Ƹ�
    public int Max_P_Armor; // �÷��̾� �ִ� �Ƹ�

    public float MoveSpeed = 2.0f; // �⺻ �ȱ�ӵ�
    public float SprintSpeed = 5.3f; // �ٴ¼ӵ�

    [Header("ī�޶� ���� ����")]
    public GameObject CinemachineCameraTarget;
    private float _cinemachineTargetYaw;
    private float _cinemachineTargetPitch;
    public float TopClamp = 70f;
    public float BottomClamp = -30f;
    public float CameraAngleOverride = 0.0f;
    private const float _threshold = 0.01f;
    public bool LockCameraPosition = false;


    public bool isReload = false;



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
        _rigidbody = GetComponent<Rigidbody>();
        _mainCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        _input = GetComponent<CharacterInputSystem>();
        _playerinput = GetComponent<PlayerInput>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        Move(); // ������
        CameraRotation();
    }

    private void LateUpdate()
    {

    }



    private void Move() // �÷��̾� �̵�
    {
        float targetSpeed = _input.sprint ? SprintSpeed : MoveSpeed; // input �� �϶� sprintspeed, ������ �� movespeed
        Vector3 inputDirection = new Vector3(_input.move.x, 0.0f, _input.move.y).normalized;

        if (_input.move == Vector2.zero)
        {
            targetSpeed = 0f;
        }


/*        if (_input.move != Vector2.zero&&!_input.aim)
        {
            _targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg;
            float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity, RotationSmoothTime);

            //transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f); // 

            //transform.LookAt(_mainCamera.transform.forward);

        }*/

        Vector3 moveDirection = _mainCamera.transform.TransformDirection(inputDirection); // ī�޶� �������� input���� �ٲ���
        moveDirection.y = 0f;
        Vector3 moveVector = moveDirection * targetSpeed ;
        //_rigidbody.MovePosition(moveVector);

        _rigidbody.velocity = new Vector3(moveVector.x, _rigidbody.velocity.y, moveVector.z);

        if (moveVector.magnitude > 0f&&!_input.aim)
        {
            Quaternion newRotation = Quaternion.LookRotation(moveDirection);//, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10f);
        }

        // �ȱ�/�ٱ� �ִϸ��̼� ���
        _animator.SetFloat("Speed", targetSpeed);
    }


    private void CameraRotation() // ī�޶� ȸ��
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
        if(_input.aim)
        {
            transform.rotation = Quaternion.Euler(/*_cinemachineTargetPitch + CameraAngleOverride*/0f, _cinemachineTargetYaw, 0.0f);

        }
    }

    private static float ClampAngle(float IfAngle, float IfMin, float IfMax) // ī�޶� ���� ����
    {
        if (IfAngle < -360f) IfAngle += 360f;
        if (IfAngle > 360f) IfAngle -= 360f;
        return Mathf.Clamp(IfAngle, IfMin, IfMax);
    }
}