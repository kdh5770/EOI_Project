using Cinemachine;
using JetBrains.Annotations;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.InputSystem.XR;

public enum CharacterSTATE
{
    MOVE,
    ATTACK,
    SKILL,
    SUIT,
    SCENEPLAY,
    INTERACTION,
    REACTION,
    DEATH
}

public class CharacterStateController : MonoBehaviour, IStateMachine
{
    public new Rigidbody rigidbody;
    public Animator animator;
    public Camera mainCamera;
    public CharacterHealth health;
    public PlayerAnimationEvent playerAnimationEvent;
    public WeaponData Data;
    public Vector3 inputDir;
    public float moveSpeed = 5.3f; // �⺻ �ȱ�ӵ�
    public float sprintSpeed = 5.3f; // �ٴ¼ӵ�
    public float applySpeed;
    public float gravityForce = 9.8f; // �߷°� 


    public CinemachineVirtualCamera virtualCamera;
    public GameObject CinemachineCameraTarget;
    public float cinemachineTargetYaw;
    public float cinemachineTargetPitch;
    public float TopClamp = 70f;
    public float BottomClamp = -30f;

    [Header("���콺 ���� ����")]
    public float rotationSensitivity;
    private const float _threshold = 0.01f;

    public WeaponTable curWeapon;
    public List<WeaponTable> weapons;

    private Dictionary<CharacterSTATE, CharaterBaseState> states = new Dictionary<CharacterSTATE, CharaterBaseState>();

    public CharaterBaseState curState;

    public bool isSprint;
    public bool isAiming;

    // ��ų���� 
    public bool IsCloaking;
    public bool IsPsychokinesis;
    public bool IsFlying;
    [SerializeField]
    private GameObject JetEngine;

    public float flyForce = 20f;
    //private float pullDistance = 10f; // ������̴� �Ÿ�
    private LayerMask targetLayer;

    [SerializeField]
    private List<GameObject> weaponImg = new List<GameObject>();

    [SerializeField]
    private List<GameObject> Weapons = new List<GameObject>();
    int weaponnum = 0;
    public CharacterSTATE Debug_state;

    /////////////////////////////////////////////////// ��Ʈ ���� �߰��ؾ� ��.

    private void Start()
    {
        mainCamera = Camera.main;
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        health = GetComponent<CharacterHealth>();
        playerAnimationEvent = GetComponentInChildren<PlayerAnimationEvent>();
        curWeapon = weapons[0];

        InitState();
        ChangeState(CharacterSTATE.MOVE);
    }

    private void Update()
    {
        curState?.OnUpdateState();
        Debug.Log(Gamemanager.instance.cutsceneinteraction.isinteraction);
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
    }

    public void ChangeReactionState(REACT_TYPE _state)
    {

    }

    void InitState()
    {
        states.Add(CharacterSTATE.MOVE, new MoveState(gameObject.GetComponent<CharacterStateController>()));
        states.Add(CharacterSTATE.ATTACK, new AttackState(gameObject.GetComponent<CharacterStateController>()));
        states.Add(CharacterSTATE.SKILL, new SkillState(gameObject.GetComponent<CharacterStateController>()));
        states.Add(CharacterSTATE.SUIT, new SuitState(gameObject.GetComponent<CharacterStateController>()));
        states.Add(CharacterSTATE.SCENEPLAY, new ScenePlayState(gameObject.GetComponent<CharacterStateController>()));
        states.Add(CharacterSTATE.INTERACTION, new InteractionState(gameObject.GetComponent<CharacterStateController>()));
        states.Add(CharacterSTATE.REACTION, new ReactionState(gameObject.GetComponent<CharacterStateController>()));
        states.Add(CharacterSTATE.DEATH, new DeathState(gameObject.GetComponent<CharacterStateController>()));
    }

    public void MoveUpdate()
    {
        if (inputDir != Vector3.zero)
        {
            applySpeed = moveSpeed;
            animator.SetFloat("MoveSpeed", applySpeed);

            Vector3 moveVector = mainCamera.transform.TransformDirection(inputDir); // ī�޶� �������� input���� �ٲ���
            moveVector.y = 0f;
            moveVector *= applySpeed;

            /// ���� �ڵ�
            //rigidbody.AddForce(Vector3.down * gravityForce, ForceMode.Force);
            //rigidbody.velocity = new Vector3(moveVector.x, rigidbody.velocity.y, moveVector.z) + Vector3.down * gravityForce;

            /// ���� �ڵ�
            rigidbody.velocity = new Vector3(moveVector.x, rigidbody.velocity.y, moveVector.z);


        }

        else
        {
            animator.SetFloat("MoveSpeed", 0);
            rigidbody.velocity = new Vector3(0f, rigidbody.velocity.y, 0f);

        }

        //rigidbody.velocity = new Vector3(rigidbody.velocity.x, Mathf.Max(rigidbody.velocity.y - gravityForce * Time.fixedDeltaTime, rigidbody.velocity.z));

        rigidbody.velocity += Vector3.down * gravityForce * Time.fixedDeltaTime;

        if (curWeapon.Data.CurBullet <= 0)
        {
            animator.SetLayerWeight(1, 0);
        }
    }

    public void ApplyGravity()
    {
        // �߷��� �����Ͽ� ���������� ��
        rigidbody.velocity += Vector3.down * gravityForce * Time.deltaTime;
    }


    public void RotateUpdate()
    {
        transform.rotation = Quaternion.Euler(0f, cinemachineTargetYaw, 0.0f);
        CinemachineCameraTarget.transform.rotation = Quaternion.Euler(cinemachineTargetPitch + 0f, cinemachineTargetYaw, 0.0f);
    }

    private static float ClampAngle(float IfAngle, float IfMin, float IfMax) // ī�޶� ���� ����
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
            return;
        }

        inputDir = new Vector3(_context.ReadValue<Vector2>().x, 0f, _context.ReadValue<Vector2>().y);
    }

    /*    public void OnSprint(InputAction.CallbackContext _context)
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
        }*/

    public void OnCamRotation(InputAction.CallbackContext _context)
    {
        if (_context.ReadValue<Vector2>().sqrMagnitude >= _threshold)
        {
            Vector2 mouseDir = _context.ReadValue<Vector2>();
            //Vector2 mouseDir = _context.ReadValue<Vector2>().normalized; // ������ ��� ������ ����.
            cinemachineTargetYaw += mouseDir.x * rotationSensitivity * Time.deltaTime;
            cinemachineTargetPitch += mouseDir.y * rotationSensitivity * Time.deltaTime;
        }

        cinemachineTargetYaw = ClampAngle(cinemachineTargetYaw, float.MinValue, float.MaxValue);
        cinemachineTargetPitch = ClampAngle(cinemachineTargetPitch, BottomClamp, TopClamp);
    }

    /*    public void OnAim(InputAction.CallbackContext _context)
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
            }
        }*/

    public void OnShoot(InputAction.CallbackContext _context)
    {
        if (_context.performed && curWeapon.Data.CurBullet > 0 && !animator.GetCurrentAnimatorStateInfo(1).IsTag("Reload"))
        {
            ChangeState(CharacterSTATE.ATTACK);

            if (curState == states[CharacterSTATE.ATTACK])
            {
                if (_context.interaction is HoldInteraction)
                {
                    curWeapon.canShooting = true;
                    animator.SetBool(curWeapon.Data.triggerName, curWeapon.canShooting);
                    curWeapon.Using();
                    animator.SetLayerWeight(1, 1);
                }

                else if (_context.interaction is PressInteraction)
                {
                    curWeapon.canShooting = true;
                    animator.SetBool(curWeapon.Data.triggerName, curWeapon.canShooting);
                    curWeapon.Using();
                    animator.SetLayerWeight(1, 1);
                }
            }
        }

        else if (_context.canceled)
        {
            curWeapon.canShooting = false;
            animator.SetBool(curWeapon.Data.triggerName, curWeapon.canShooting);
            animator.SetLayerWeight(1, 0);
        }
    }

    public void OnPotion(InputAction.CallbackContext _context)
    {
        if (_context.performed && curState == states[CharacterSTATE.MOVE])
        {
            health.UsingPortion();
        }
    }

    public void OnReload(InputAction.CallbackContext _context)
    {
        if (_context.performed && !curWeapon.canShooting && curWeapon.Data.CurBullet < curWeapon.Data.MaxBullet)
        {
            animator.SetLayerWeight(1, 1);
            animator.SetTrigger("Reload");
            curWeapon.Data.CurBullet = curWeapon.Data.MaxBullet;
        }
    }

    public void OnFlying(InputAction.CallbackContext _context)
    {
        if (_context.performed)
        {
            ChangeState(CharacterSTATE.SKILL);
            if (_context.interaction is HoldInteraction)
            {
                IsFlying = true;
                JetEngine.SetActive(true);
            }
        }

        else if (_context.canceled)
        {
            IsFlying = false;
            JetEngine.SetActive(false);
        }
    }



    public void OnCloaking(InputAction.CallbackContext _context)
    {

    }

    public void OnInterAction(InputAction.CallbackContext _context)
    {
        if (_context.performed)
        {
            ChangeState(CharacterSTATE.INTERACTION);

        }
    }

    public void OnPsychokinesis(InputAction.CallbackContext _context)
    {
        if (_context.performed)
        {
            ChangeState(CharacterSTATE.SKILL);
        }

        else if (_context.canceled)
            ChangeState(CharacterSTATE.MOVE);
    }

    public void OnChangeWeapon(InputAction.CallbackContext _context)
    {
        if (_context.performed)
        {
            weapons[weaponnum].gameObject.SetActive(false);
            weaponImg[weaponnum].gameObject.SetActive(false);
            weaponnum++;

            if (weaponnum >= weapons.Count)
            {
                weaponnum = 0;
            }
        }

        weapons[weaponnum].gameObject.SetActive(true);
        weaponImg[weaponnum].gameObject.SetActive(true);
        curWeapon = weapons[weaponnum];
    }
}