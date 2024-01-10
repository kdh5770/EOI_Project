using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
public class Character_Action : MonoBehaviour
{
    [SerializeField]
    private Character character;
    [Header("에임관련")]
    [SerializeField]
    private CinemachineVirtualCamera AimCam;
    [SerializeField]
    private GameObject aimObj;
    [SerializeField]
    private float aimObjDis = 10f;
    [SerializeField]
    private LayerMask targetLayer;

    private PlayerInput _playerinput;
    private CharacterInputSystem _input;

    private Animator _animator;

    public bool isAimMove = false;
    public bool isReload = false;


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _input = GetComponent<CharacterInputSystem>();
        character = GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        OnAim();

        if (_input.reload)
        {
            _input.reload = false;
            AimControll(false);

            if (character.isReload)
            {
                return;
            }
            //_animator.SetLayerWeight(1, 1);
            _animator.SetTrigger("Reload");
        }
    }

    void OnAim()
    {
        if (_input.aim)
        {
            AimControll(true);

            //_animator.SetLayerWeight(1, 1);

            Transform camTransform = Camera.main.transform;
            RaycastHit hit;

            Vector3 targetPosition = Vector3.zero;

            if (Physics.Raycast(camTransform.position, camTransform.forward, out hit, Mathf.Infinity, targetLayer))
            {
                targetPosition = hit.point;
                aimObj.transform.position = hit.point;
            }
            else
            {
                targetPosition = camTransform.position + camTransform.forward * aimObjDis;
                aimObj.transform.position = camTransform.position + camTransform.forward * aimObjDis;


            }

            Vector3 targetAim = targetPosition;
            targetAim.y = transform.position.y;
            Vector3 aimDir = (targetAim - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDir, Time.deltaTime * 30f);

            if (_input.shoot)
            {
                _animator.SetBool("Shoot", true);
            }
            else
            {
                _animator.SetBool("Shoot", false);
            }

        }

        else
        {
            AimControll(false);

            //_animator.SetLayerWeight(1, 0);
            _animator.SetBool("Shoot", false);
        }
    }


    void AimControll(bool isCheck)
    {
        AimCam.gameObject.SetActive(isCheck);
    }
}
