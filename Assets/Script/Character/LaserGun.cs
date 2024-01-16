using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : WeaponTable
{
    public override void Initsetting()
    {
        Data.ShotDelay = 0.5f;
        Data.MaxBullet = 30;
        Data.CurBullet = 30;
        Data.Damage = 10;
    }

    public override void Using()
    {
        base.Using();
    }

}
