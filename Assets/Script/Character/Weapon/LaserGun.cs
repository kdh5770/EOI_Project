using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LaserGun : WeaponTable
{
    public LineRenderer laserEffect;
    public Transform shotLaserGunPos;
    private WaitForSeconds shotDelay;
    private IEnumerator usingCor;
    private LayerMask targetlayer;

    private void Start()
    {
        Initsetting();
        shotDelay = new WaitForSeconds(Data.ShotDelay);
        laserEffect = GetComponent<LineRenderer>();
        laserEffect.enabled = false;
    }

    public override void Initsetting()
    {
        Data.ShotDelay = 0.01f;
        Data.MaxBullet = 30;
        Data.CurBullet = 30;
        Data.Damage = 5;
        Data.triggerName = "IsLaserGun";
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
        //GameObject Laser = Instantiate(laserE
        //ffect, shotLaserGunPos.position, Quaternion.identity);


        while (canShooting)
        {
            laserEffect.enabled = true;
            RaycastHit hit;

            Vector3 mousePos = Mouse.current.position.ReadValue();
            Ray ray = camera.ScreenPointToRay(mousePos);

            laserEffect.SetPosition(0, shotLaserGunPos.position);

            if (Physics.Raycast(ray, out hit, 500f, targetlayer))
            {
                Vector3 directionToHit = (hit.point - shotLaserGunPos.position).normalized;
                laserEffect.SetPosition(1, shotLaserGunPos.position + directionToHit);
                if (hit.collider.CompareTag("Monster"))
                {
                    hit.collider.GetComponent<Weakness>().AttackDamage(Data.Damage, hit.point);
                }
            }
            else
                laserEffect.SetPosition(1, shotLaserGunPos.position + shotLaserGunPos.forward * 500f);

            yield return shotDelay;
        }
        laserEffect.enabled = false;
        usingCor = null;
    }
}
