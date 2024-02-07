using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : WeaponTable
{
    public Transform shotPos;
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
        Data.ShotDelay = 0.3f;
        Data.MaxBullet = 30;
        Data.CurBullet = 30;
        Data.Damage = 10;
        Data.triggerName = "IsFireGun";
    }

    public override void Using()
    {
        if(usingCor==null)
        {
            usingCor = UsingCor();
        }
    }


    IEnumerator UsingCor()
    {
        while (canShooting)
        {
            Instantiate(FireEffect,shotPos.position, Quaternion.identity);

            





            yield return shotDelay;
/*            if (hit.collider.CompareTag("Monster"))
            {
                hit.collider.GetComponent<Weakness>().AttackDamage(Data.Damage, hit.point);
            }*/
        }
        usingCor = null;
    }
}
