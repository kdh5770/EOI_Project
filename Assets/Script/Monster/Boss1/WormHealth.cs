using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WormHealth : MonsterStatus
{
    public event Action LowHealthEvent;
    
    public Slider HP;
    public int count = 0;

    public override void CalculateDamage(float _damage)
    {
        base.CalculateDamage(_damage);

        if(curHP <= maxHP * .3)
        {
            LowHealthEvent?.Invoke();
        }
    }
}