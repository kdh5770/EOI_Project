using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class MachineGun : WeaponTable
{
    public Transform shotMachineGunPos;
    public GameObject shotFlash;
    public TrailRenderer shotTrail;
    public GameObject impactEft;
    private WaitForSeconds shotDelay;
    private IEnumerator usingCor;

    [SerializeField]
    private GameObject ShootFlx;
    [SerializeField]
    private Transform machinegunShotpos;

    [SerializeField]
    private AudioSource gunAudioSource;  // 사운드를 재생할 AudioSource
    [SerializeField]
    private AudioClip gunShotClip;       // 사격 사운드 클립

    private void Start()
    {
        Initsetting();
        shotDelay = new WaitForSeconds(Data.ShotDelay);
    }
    public override void Initsetting()
    {
        Data.ShotDelay = .1f;
        Data.MaxBullet = 30;
        Data.CurBullet = 30;
        Data.Damage = 5;
        Data.triggerName = "IsMachineGun";
    }

    public override void Using()
    {
        if (usingCor == null)
        {
            //usingCor = UsingCor();
            //StartCoroutine(usingCor);

            // 총알 쏘는 로직

            usingCor = BulletShootCo();
            StartCoroutine(usingCor);
        }
    }

    IEnumerator UsingCor()
    {
        while (canShooting)
        {
            Vector3 mousePos = Mouse.current.position.ReadValue();
            Ray ray = camera.ScreenPointToRay(mousePos);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask))
            {
                //StartCoroutine(SpawnTrail(hit));
                if (hit.collider.CompareTag("Monster"))
                {
                    hit.collider.GetComponent<Weakness>().AttackDamage(Data.Damage, hit.point);
                }
            }
            yield return shotDelay;
        }
        usingCor = null;
    }

    IEnumerator BulletShootCo()
    {
        while (canShooting)
        {
            if (Data.CurBullet <= 0)
            {
                canShooting = false;
                break;
            }
           
            Vector3 mousePos = Mouse.current.position.ReadValue();
            Ray ray = camera.ScreenPointToRay(mousePos);
            Instantiate(ShootFlx, machinegunShotpos);

            gunAudioSource.PlayOneShot(gunShotClip);
            Data.CurBullet--;

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask))
            {
                if (hit.collider.CompareTag("Monster"))
                {
                    //hit.collider.GetComponent<Weakness>().AttackDamage(Data.Damage, hit.point);
                }

                Vector3 directionToHit = (hit.point - shotMachineGunPos.position).normalized;
                GameObject bullet = Gamemanager.instance.poolManager.GetBullet();
                if (bullet != null)
                {
                    bullet.SetActive(true);
                    bullet.GetComponent<CharacterBullet>().SetBulle(Data.Damage);
                    bullet.transform.position = shotMachineGunPos.position;
                    bullet.transform.rotation = Quaternion.LookRotation(directionToHit);
                    bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 20f, ForceMode.Impulse);
                }
            }
            yield return shotDelay;
        }

        usingCor = null;
    }

    IEnumerator SpawnTrail(RaycastHit hit)
    {
        TrailRenderer trail = Instantiate(shotTrail, shotMachineGunPos.position, Quaternion.identity);

        yield return null;

        trail.transform.position = hit.point;
        GameObject eftObj = Instantiate(impactEft, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(eftObj, 1f);
        Destroy(trail.gameObject, .1f);
    }
}