using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.Windows;

public class CharacterStateController : MonoBehaviour, IStateMachine
{
    public Rigidbody rigidbody;
    public Animator animator;
    public Camera mainCamera;
    public CharacterHealth health;

    public Vector3 inputDir;
    public float moveSpeed = 2.0f; // 기본 걷기속도
    public float sprintSpeed = 5.3f; // 뛰는속도
    public float applySpeed;

    public GameObject CinemachineCameraTarget;
    public float cinemachineTargetYaw;
    public float cinemachineTargetPitch;
    public float TopClamp = 70f;
    public float BottomClamp = -30f;
    public float rotationSensitivity;

    public CharaterBaseState curState;
    MoveState moveState;
    AttackState attackState;
    SkillState skillState;
    ReactionState reactionState;
    CutSceneState cutSceneState;
    DeathState deathState;

    public bool isSprint;
    public bool isAiming;
    public bool canShooting;

    private void Start()
    {
        mainCamera = Camera.main;
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        health = GetComponent<CharacterHealth>();

        Cursor.lockState = CursorLockMode.Locked;

        rotationSensitivity = 100f;

        InitState();
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

    void InitState()
    {
        moveState = new MoveState(gameObject.GetComponent<CharacterStateController>());
        attackState = new AttackState(gameObject.GetComponent<CharacterStateController>());
        skillState = new SkillState(gameObject.GetComponent<CharacterStateController>());
        reactionState = new ReactionState(gameObject.GetComponent<CharacterStateController>());
        cutSceneState = new CutSceneState(gameObject.GetComponent<CharacterStateController>());
        deathState = new DeathState(gameObject.GetComponent<CharacterStateController>());
    }


    private static float ClampAngle(float IfAngle, float IfMin, float IfMax) // 카메라 각도 관련
    {
        if (IfAngle < -360f) IfAngle += 360f;
        if (IfAngle > 360f) IfAngle -= 360f;
        return Mathf.Clamp(IfAngle, IfMin, IfMax);
    }

    public void OnMoveInput(InputAction.CallbackContext _context)
    {
        if (_context.ReadValue<Vector2>() == Vector2.zero)
        {
            inputDir = Vector3.zero;
        }

        inputDir = new Vector3(_context.ReadValue<Vector2>().x, 0f, _context.ReadValue<Vector2>().y);
    }

    public void OnSprint(InputAction.CallbackContext _context)
    {
        if (_context.performed)
        {
            if (_context.interaction is HoldInteraction)
            {
                isSprint = true;
            }
        }
        else
        {
            isSprint = false;
        }

    }

    public void OnCamRotation(InputAction.CallbackContext _context)
    {
        if (_context.ReadValue<Vector2>() == Vector2.zero)
        {
            return;
        }

        Vector2 mouseDir = _context.ReadValue<Vector2>().normalized;
        cinemachineTargetYaw += mouseDir.x * rotationSensitivity * Time.deltaTime;
        cinemachineTargetPitch += mouseDir.y * rotationSensitivity * Time.deltaTime;

        cinemachineTargetYaw = ClampAngle(cinemachineTargetYaw, float.MinValue, float.MaxValue);
        cinemachineTargetPitch = ClampAngle(cinemachineTargetPitch, BottomClamp, TopClamp);

    }

    public void OnAim(InputAction.CallbackContext _context)
    {
        if (_context.performed)
        {
            if (_context.interaction is HoldInteraction)
            {
                isAiming = true;
                animator.SetLayerWeight(1, 1);
                Debug.Log("에임");
            }
        }
        if (_context.canceled)
        {
            isAiming = false;
            animator.SetLayerWeight(1, 0);
            Debug.Log("not,에임");
        }
    }

    public void OnShoot(InputAction.CallbackContext _context)
    {
        if (isAiming && canShooting)
        {
            if (_context.interaction is HoldInteraction)
            {
                if (_context.performed)
                {
                    animator.SetTrigger("IsShoot");
                    Debug.Log("shoot");
                }
            }
        }
    }
}
