using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : WeaponTest
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
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
