using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MachineGun : WeaponTable
{
    public Transform shotPos;
    public GameObject shotFlash;
    public TrailRenderer shotTrail;
    public GameObject impactEft;
    private WaitForSeconds shotDelay;
    private IEnumerator usingCor;

    // ºÒ¸´ ÇÁ¸®ÆÕÀ¸·Î ³ª°¡°Ô
    public GameObject BulletPrefab;
    public Transform BulletShootPos;
    public float bulspd = 30f;


    private void Start()
    {
        Initsetting();
        shotDelay = new WaitForSeconds(Data.ShotDelay);
    }
    public override void Initsetting()
    {
        Data.ShotDelay = 1f;
        Data.MaxBullet = 30;
        Data.CurBullet = 30;
        Data.Damage = 10;
        Data.triggerName = "IsMachineGun";
    }

    public override void Using()
    {
        if (usingCor == null)
        {
            //usingCor = UsingCor();
            //StartCoroutine(usingCor);

            // ÃÑ¾Ë ½î´Â ·ÎÁ÷
            usingCor = BulletShootCo();
            StartCoroutine(BulletShootCo());
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
                StartCoroutine(SpawnTrail(hit));
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
            Vector3 mousePos = Mouse.current.position.ReadValue();
            Ray ray = camera.ScreenPointToRay(mousePos);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask))
            {
                StartCoroutine(BulletInstanceCo());
                if (hit.collider.CompareTag("Monster"))
                {
                    hit.collider.GetComponent<Weakness>().AttackDamage(Data.Damage, hit.point);
                }
            }
            yield return shotDelay;
        }
        usingCor = null;
    }

    IEnumerator BulletInstanceCo()
    {
        GameObject bullet= Instantiate(BulletPrefab, BulletShootPos.position, Quaternion.identity);
        Rigidbody bulRig = bullet.GetComponent<Rigidbody>();
        bulRig.velocity= BulletShootPos.forward * bulspd*Time.deltaTime;

        yield return null;
    }


    private IEnumerator SpawnTrail(RaycastHit hit)
    {
        TrailRenderer trail = Instantiate(shotTrail, shotPos.position, Quaternion.identity);

        yield return null;

        trail.transform.position = hit.point;
        GameObject eftObj = Instantiate(impactEft, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(eftObj, 1f);
        Destroy(trail.gameObject, .1f);
    }
}
