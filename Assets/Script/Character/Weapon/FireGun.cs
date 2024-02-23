using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireGun : WeaponTable
{
    public Transform shotFireGunPos;
    public GameObject FireEffect;
    private WaitForSeconds shotDelay;
    private IEnumerator usingCor;
    private void Start()
    {
        Initsetting();
        shotDelay = new WaitForSeconds(Data.ShotDelay);
    }
    public override void Initsetting()
    {
        Data.ShotDelay = 0.03f;
        Data.MaxBullet = 300;
        Data.CurBullet = 300;
        Data.Damage = 1;
        Data.triggerName = "IsFireGun";
    }

    public override void Using()
    {
        if (usingCor == null)
        {
            usingCor = UsingCor();
            StartCoroutine(usingCor);
        }
    }

    IEnumerator UsingCor()
    {
        GameObject Fire = Instantiate(FireEffect, shotFireGunPos.position, Quaternion.identity);

        while (canShooting)
        {

            if (Data.CurBullet <= 0)
            {
                canShooting = false;
                break;
            }

            Vector3 mousePos = Mouse.current.position.ReadValue();
            Ray ray = camera.ScreenPointToRay(mousePos);
            Fire.transform.position = shotFireGunPos.position;
            Fire.transform.rotation = Quaternion.LookRotation(ray.direction);
            Data.CurBullet--;

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask, QueryTriggerInteraction.Collide))
            {
                if (hit.collider.CompareTag("Monster"))
                {
                    hit.collider.GetComponent<Weakness>().AttackDamage(Data.Damage, hit.point);
                }
            }
            yield return shotDelay;
        }

        Destroy(Fire, 0.1f);
        usingCor = null;
    }
}