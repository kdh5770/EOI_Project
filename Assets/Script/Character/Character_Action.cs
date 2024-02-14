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

    //public GameObject spotLight;

    [Header("트레일 렌더러 관련")]

    [SerializeField]
    private GameObject ShootFlx;

    //private ParticleSystem ShootingSystem;
    [SerializeField]
    private Transform Shootposition;
    [SerializeField]
    private ParticleSystem ImpactParticleSystem;
    [SerializeField]
    private TrailRenderer BulletTrail;
    [SerializeField]
    private LayerMask Mask;

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
        if (_input.sprint)
        {
            _input.shoot = false;
        }

        //OnAim();
        if (_input.reload)
        {
            _input.reload = false;
            //AimControll(false);

            if (character.isReload)
            {
                return;
            }
            _animator.SetLayerWeight(1, 1);
            _animator.SetTrigger("Reload");
        }
    }


/*    void OnAim()
    {
        if (_input.aim && !_input.sprint)
        {
            AimControll(true);

            _animator.SetLayerWeight(1, 1);

            Vector3 targetPosition = Vector3.zero;

            if (Physics.Raycast(camTransform.position, camTransform.forward, out hit, Mathf.Infinity, targetLayer))
            {
                targetPosition = hit.point;
                aimObj.transform.position = hit.point;
                //spotLight.transform.LookAt(aimObj.transform.position);
            }

            else
            {
                targetPosition = camTransform.position + camTransform.forward * aimObjDis;
                aimObj.transform.position = camTransform.position + camTransform.forward * aimObjDis;
                //spotLight.transform.LookAt(aimObj.transform.position);
            }

            *//*            Vector3 targetAim = targetPosition;
                        targetAim.y = transform.position.y;
                        Vector3 aimDir = (targetAim - transform.position).normalized;

                        transform.forward = Vector3.Lerp(transform.forward, aimDir, Time.deltaTime * 30f);*//*

        }

        else
        {
            AimControll(false);
            _animator.SetLayerWeight(1, 0);
            //_animator.SetBool("Shoot", false);
        }
    }*/

/*    void AimControll(bool isCheck)
    {
        AimCam.gameObject.SetActive(isCheck);
        //AimImage.SetActive(isCheck);
        _animator.SetBool("Aiming", isCheck);
    }
*/
    public void OnShoot()
    {
        if (/*_input.aim && */!_animator.GetCurrentAnimatorStateInfo(1).IsTag("Shoot") && !_input.sprint)
        {
            _animator.SetTrigger("ShootTri");
            Instantiate(ShootFlx, Shootposition);
            //ShootingSystem.Play();
            Vector3 directioin = GetDirection();


            if (Physics.Raycast(camTransform.position, camTransform.forward, out hit, Mathf.Infinity, targetLayer))
            {
                TrailRenderer trail = Instantiate(BulletTrail, Shootposition.position, Quaternion.identity);

                StartCoroutine(SpawnTrail(trail, hit));

                if (hit.collider.CompareTag("Monster"))
                {
                    hit.collider.GetComponent<Weakness>().AttackDamage(10, hit.point);
                    Instantiate(ImpactParticleSystem, hit.point, Quaternion.LookRotation(hit.normal));
                    GameObject eftObj = Instantiate(BloodObj, hit.point, Quaternion.identity);
                    eftObj.transform.LookAt(camTransform.transform.position);
                    Destroy(eftObj, 1f);                  
                }
                else
                {
                    Instantiate(ImpactParticleSystem, hit.point, Quaternion.LookRotation(hit.normal));
                }
            }
        }
    }


    private Vector3 GetDirection()
    {
        Vector3 direction = transform.forward;

        direction.Normalize();
        return direction;
    }

    private IEnumerator SpawnTrail(TrailRenderer Trail, RaycastHit hit)
    {
        float time = 0f;
        Vector3 startPosition = Trail.transform.position;
        while (time < 1f)
        {
            Trail.transform.position = Vector3.Lerp(startPosition, hit.point, time);
            time += Time.deltaTime / Trail.time;
            yield return null;
        }

        Trail.transform.position = hit.point;

        Destroy(Trail.gameObject, Trail.time);

    }

}