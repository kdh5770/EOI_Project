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
    public WeaponData Data;
    public Vector3 inputDir;
    public float moveSpeed = 5.3f; // 기본 걷기속도
    public float sprintSpeed = 5.3f; // 뛰는속도
    public float applySpeed;

    public CinemachineVirtualCamera virtualCamera;
    public GameObject CinemachineCameraTarget;
    public float cinemachineTargetYaw;
    public float cinemachineTargetPitch;
    public float TopClamp = 70f;
    public float BottomClamp = -30f;

    [Header("마우스 감도 설정")]
    public float rotationSensitivity;
    private const float _threshold = 0.01f;

    public WeaponTable curWeapon;
    public List<WeaponTable> weapons;

    private Dictionary<CharacterSTATE, CharaterBaseState> states = new Dictionary<CharacterSTATE, CharaterBaseState>();

    public CharaterBaseState curState;




    public bool isSprint;
    public bool isAiming;

    // 스킬관련 
    public bool IsCloaking;
    public bool IsPsychokinesis;
    public bool IsFlying;
    [SerializeField]
    private GameObject JetEngine;

    public float flyForce = 20f;
    private float gravitationalForce = 10f; // 중력
    //private float pullDistance = 10f; // 끌어들이는 거리
    private LayerMask targetLayer;


    [SerializeField]
    private List<GameObject> weaponImg = new List<GameObject>();

    [SerializeField]
    private List<GameObject> Weapons = new List<GameObject>();
    int weaponnum = 0;
    public CharacterSTATE Debug_state;



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
        //Debug.Log(_state.ToString());
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
            applySpeed = moveSpeed;
            animator.SetFloat("MoveSpeed", applySpeed);

            Vector3 moveVector = mainCamera.transform.TransformDirection(inputDir); // 카메라 기준으로 input값을 바꿔줌
            moveVector.y = 0f;
            moveVector *= applySpeed;
            rigidbody.velocity = new Vector3(moveVector.x, rigidbody.velocity.y, moveVector.z);

            /////////////////
            /*            if (moveVector.magnitude > 0f && !isAiming)
                        {
                            Quaternion newRotation = Quaternion.LookRotation(moveVector);//, Vector3.up);
                            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10f);
                        }*/
        }
        else
        {
            animator.SetFloat("MoveSpeed", 0);
            rigidbody.velocity = Vector3.zero;
        }
    }

    public void RotateUpdate()
    {
        /*        if (isAiming)*/
        transform.rotation = Quaternion.Euler(0f, cinemachineTargetYaw, 0.0f);

        CinemachineCameraTarget.transform.rotation = Quaternion.Euler(cinemachineTargetPitch + 0f, cinemachineTargetYaw, 0.0f);
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
            return;
        }

        inputDir = new Vector3(_context.ReadValue<Vector2>().x, 0f, _context.ReadValue<Vector2>().y);
    }

    public void OnSprint(InputAction.CallbackContext _context)
    {
        if (/*!isAiming &&*/curState == states[CharacterSTATE.MOVE])
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
        if (_context.ReadValue<Vector2>().sqrMagnitude >= _threshold)
        {
            Vector2 mouseDir = _context.ReadValue<Vector2>();
            //Vector2 mouseDir = _context.ReadValue<Vector2>().normalized; // 프레임 드랍 문제가 있음.
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
        if (_context.performed && !isSprint && curWeapon.Data.CurBullet > 0)
        {
            ChangeState(CharacterSTATE.ATTACK);
            if (curState == states[CharacterSTATE.ATTACK])
            {
                if (_context.interaction is HoldInteraction)
                {
                    curWeapon.canShooting = true;
                    animator.SetBool(curWeapon.Data.triggerName, curWeapon.canShooting);
                    curWeapon.Using();
                    //curWeapon.Data.CurBullet--;
                    animator.SetLayerWeight(1, 1);
                }
                else if (_context.interaction is PressInteraction)
                {
                    curWeapon.canShooting = true;
                    animator.SetBool(curWeapon.Data.triggerName, curWeapon.canShooting);
                    curWeapon.Using();
                    //curWeapon.Data.CurBullet--;
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

    public void OnFlying(InputAction.CallbackContext _context)
    {
        if (_context.performed)
        {
            if (_context.interaction is HoldInteraction)
            {
                IsFlying = true;
                JetEngine.SetActive(true);
                rigidbody.useGravity = false;
                rigidbody.AddForce(Vector3.up * flyForce, ForceMode.Impulse);
            }
        }

        else if (_context.canceled)
        {
            IsFlying = false;
            JetEngine.SetActive(false);
            rigidbody.useGravity = true;
        }
    }

    public void OnCloaking(InputAction.CallbackContext _context)
    {

    }

    public void OnPsychokinesis(InputAction.CallbackContext _context)
    {
        if (_context.performed)
        {
            Vector3 mousePos = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 50f, targetLayer))
            {
                if (hit.collider.CompareTag("Monster"))
                {
                    Transform monsterTransform = hit.collider.transform;
                    Vector3 playerPosition = transform.position;

                    // 몬스터와 플레이어 사이의 방향 벡터
                    Vector3 direction = (monsterTransform.position - playerPosition).normalized;
                    monsterTransform.position -= direction * gravitationalForce * Time.deltaTime;
                }


            }
        }
    }

    public void OnChangeWeapon(InputAction.CallbackContext _context)
    {
        if (_context.performed)
        {
            weapons[weaponnum].gameObject.SetActive(false);
            weaponImg[weaponnum].gameObject.SetActive(false);
            weaponnum++;
        }
        if (weaponnum >= weapons.Count)
        {
            weaponnum = 0;
        }

        weapons[weaponnum].gameObject.SetActive(true);
        weaponImg[weaponnum].gameObject.SetActive(true);
        curWeapon = weapons[weaponnum];
    }
}