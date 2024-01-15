using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
using TMPro;

public class Character_Action : MonoBehaviour
{
    [SerializeField]
    private Character character;

    [Header("에임관련")]
    Transform camTransform;
    [SerializeField]
    private CinemachineVirtualCamera AimCam;
    [SerializeField]
    private GameObject aimObj;
    [SerializeField]
    private float aimObjDis = 10f;
    [SerializeField]
    private LayerMask targetLayer;
    [SerializeField]
    private GameObject AimImage; // 조준선

    [SerializeField]
    private GameObject BloodObj;
   
    private CharacterInputSystem _input;

    private Animator _animator;

    public bool isAimMove = false;
    public bool isReload = false;
    RaycastHit hit;

    public GameObject spotLight;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _input = GetComponent<CharacterInputSystem>();
        character = GetComponent<Character>();
        camTransform = Camera.main.transform;
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
        if (_input.aim && !_input.sprint)
        {
            AimControll(true);

            //_animator.SetLayerWeight(1, 1);

            Vector3 targetPosition = Vector3.zero;

            if (Physics.Raycast(camTransform.position, camTransform.forward, out hit, Mathf.Infinity, targetLayer))
            {
                targetPosition = hit.point;
                aimObj.transform.position = hit.point;
                spotLight.transform.LookAt(aimObj.transform.position);
            }

            else
            {
                targetPosition = camTransform.position + camTransform.forward * aimObjDis;
                aimObj.transform.position = camTransform.position + camTransform.forward * aimObjDis;
                spotLight.transform.LookAt(aimObj.transform.position);
            }

/*            Vector3 targetAim = targetPosition;
            targetAim.y = transform.position.y;
            Vector3 aimDir = (targetAim - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDir, Time.deltaTime * 30f);*/
            
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
        AimImage.SetActive(isCheck);
    }

    public void OnShoot()
    {
        if(_input.aim)
        {
            _animator.SetTrigger("ShootTri");
            if (Physics.Raycast(camTransform.position, camTransform.forward, out hit, Mathf.Infinity, targetLayer))
            {
                GameObject eftObj = Instantiate(BloodObj, hit.transform.position, Quaternion.identity);
                eftObj.transform.LookAt(transform.position);
                
                //eftObj.transform.rotation = Quaternion.Euler(eftObj.transform.rotation.eulerAngles.x, 90f, eftObj.transform.rotation.eulerAngles.z);
                Destroy(eftObj, 2f);
            }
        }
    }




}