using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterStateController : MonoBehaviour, IStateMachine
{
    public CharacterInputSystem _input;
    public Rigidbody _rigidbody;
    public Animator _animator;
    public Camera _mainCamera;
    public CharaterBaseState curState;

    public float MoveSpeed = 2.0f; // ±âº» °È±â¼Óµµ
    public float SprintSpeed = 5.3f; // ¶Ù´Â¼Óµµ

    public GameObject CinemachineCameraTarget;
    private float _cinemachineTargetYaw;
    private float _cinemachineTargetPitch;
    public float TopClamp = 70f;
    public float BottomClamp = -30f;
    public float CameraAngleOverride = 0.0f;
    private const float _threshold = 0.01f;
    public bool LockCameraPosition = false;


    public MoveState moveState;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _mainCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        _input = GetComponent<CharacterInputSystem>();
        _animator = GetComponentInChildren<Animator>();

        moveState = new MoveState();
        moveState.InitState(gameObject.GetComponent<CharacterStateController>());

        ChangeState(moveState);

    }

    private void Update()
    {
        curState.OnUpdateState();
    }

    private void FixedUpdate()
    {
        curState.OnFixedUpdateState();
    }

    public void ChangeState(CharaterBaseState _state)
    {
        curState?.OnExitState();
        curState = _state;
        curState?.OnEnterState();
    }

    public void ChangeReactionState(REACT_TYPE _state)
    {
        throw new System.NotImplementedException();
    }
}
