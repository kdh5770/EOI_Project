using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMelee : Attack
{
    public enum MELEE_TYPE
    {
        SINGLE,
        SEQUENTIAL,
        RANDEOM
    }    

    public MELEE_TYPE meleeType;
    
    public override void ExecuteAttack(GameObject _target)
    {
        transform.LookAt(_target.transform.position);
        animator.SetTrigger("IsMelee");
        _target.GetComponent<CharacterHealth>().TakeDamage(damage);
    }
}
