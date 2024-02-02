using Cinemachine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;


public enum CharacterSTATE
{
    MOVE,
    ATTACK,
    SKILL,
    INTERACTION,
    REACTION,
    DEATH
}

public class CharacterStateController : MonoBehaviour, IStateMachine
{
    private new Rigidbody rigidbody;
    public Animator animator;
    public Camera mainCamera;
    public CharacterHealth health;
    public PlayerAnimationEvent playerAnimationEvent;

    public Vector3 inputDir;
    public float moveSpeed = 2.0f; // 기본 걷기속도
    public float sprintSpeed = 5.3f; // 뛰는속도
    public float applySpeed;

    public CinemachineVirtualCamera virtualCamera;
    public GameObject CinemachineCameraTarget;
    public float cinemachineTargetYaw;
    public float cinemachineTargetPitch;
    public float TopClamp = 70f;
    public float BottomClamp = -30f;
    public float rotationSensitivity;

    public WeaponTable curWeapon;
    public List<WeaponTable> weapons;

    private Dictionary<CharacterSTATE, CharaterBaseState> states = new Dictionary<CharacterSTATE, CharaterBaseState>();

    public CharaterBaseState curState;

    public Rig aimIK;


    public bool isSprint;
    public bool isAiming;

    public CharacterSTATE Debug_state;

    private void Start()
    {
        mainCamera = Camera.main;
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        health = GetComponent<CharacterHealth>();
        playerAnimationEvent = GetComponentInChildren<PlayerAnimationEvent>();

        rotationSensitivity = 25f;

        curWeapon = weapons[0];

        InitState();
        ChangeState(CharacterSTATE.MOVE);
    }

    private void Update()
    {
        curState?.OnUpdateState();
    }

    private void FixedUpdate()
    {
        curState?.OnFixedUpdateState();
    }

    public void ChangeState(CharacterSTATE _state)
    {
        curState?.OnExitState();
        curState = states[_state];
        curState?.OnEnterState();
        Debug_state = _state;
        Debug.Log(_state.ToString());
    }

    public void ChangeReactionState(REACT_TYPE _state)
    {
        throw new System.NotImplementedException();
    }

    void InitState()
    {
        states.Add(CharacterSTATE.MOVE, new MoveState(gameObject.GetComponent<CharacterStateController>()));
        states.Add(CharacterSTATE.ATTACK, new AttackState(gameObject.GetComponent<CharacterStateController>()));
        states.Add(CharacterSTATE.SKILL, new SkillState(gameObject.GetComponent<CharacterStateController>()));
        states.Add(CharacterSTATE.INTERACTION, new InteractionState(gameObject.GetComponent<CharacterStateController>()));
        states.Add(CharacterSTATE.REACTION, new ReactionState(gameObject.GetComponent<CharacterStateController>()));
        states.Add(CharacterSTATE.DEATH, new DeathState(gameObject.GetComponent<CharacterStateController>()));
    }

    public void MoveUpdate()
    {
        if (inputDir != Vector3.zero)
        {
            applySpeed = isSprint ? sprintSpeed : moveSpeed;
            animator.SetFloat("MoveSpeed", applySpeed);

            Vector3 moveVector = mainCamera.transform.TransformDirection(inputDir); // 카메라 기준으로 input값을 바꿔줌
            moveVector.y = 0f;
            moveVector *= applySpeed;
            rigidbody.velocity = new Vector3(moveVector.x, rigidbody.velocity.y, moveVector.z);

            if (moveVector.magnitude > 0f && !isAiming)
            {
                Quaternion newRotation = Quaternion.LookRotation(moveVector);//, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10f);
            }
        }
        else
        {
            animator.SetFloat("MoveSpeed", 0);
            rigidbody.velocity = Vector3.zero;
        }
    }

    public void RotateUpdate()
    {
        if (isAiming)
            transform.rotation = Quaternion.Euler(0f, cinemachineTargetYaw, 0.0f);
        CinemachineCameraTarget.transform.rotation = Quaternion.Euler(cinemachineTargetPitch, cinemachineTargetYaw, 0.0f);
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
        if (!isAiming && curState == states[CharacterSTATE.MOVE])
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
                Cinemachine3rdPersonFollow follow = virtualCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>();
                follow.CameraDistance = 1;
                isAiming = true;
                isSprint = false;
                animator.SetLayerWeight(1, 1);
                animator.SetBool("IsAiming", isAiming);
                aimIK.weight = 1;
                Debug.Log("에임");
            }
        }
        if (_context.canceled)
        {
            Cinemachine3rdPersonFollow follow = virtualCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>();
            follow.CameraDistance = 2;
            isAiming = false;
            animator.SetLayerWeight(1, 0);
            animator.SetBool("IsAiming", isAiming);
            aimIK.weight = 0;
            Debug.Log("not,에임");
        }
    }

    public void OnShoot(InputAction.CallbackContext _context)
    {
        if (isAiming && curState == states[CharacterSTATE.MOVE])
        {
            if (_context.performed)
            {
                if (_context.interaction is HoldInteraction)
                {
                    ChangeState(CharacterSTATE.ATTACK);
                }
                if (_context.interaction is PressInteraction)
                {
                    ChangeState(CharacterSTATE.ATTACK);
                }
            }
        }
    }
}
