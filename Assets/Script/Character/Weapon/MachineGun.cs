using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MachineGun : WeaponTable
{
    public override void Initsetting()
    {
        Data.ShotDelay = 0.5f;
        Data.MaxBullet = 30;
        Data.CurBullet = 30;
        Data.Damage = 10;
        Data.triggerName = "IsMachineGun";
    }

    public override void Using()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        Ray ray = camera.ScreenPointToRay(mousePos);
        Debug.DrawRay(ray.origin, ray.direction, Color.red, 3f);
    }


}
