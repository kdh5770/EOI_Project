using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonsterStatus
{
    public Slider HP;
    public int count = 0;

    public override void CalculateDamage(float _damage)
    {
        base.CalculateDamage(_damage);
        if(curHP <= curHP * .3)
        {
            
        }
    }
}