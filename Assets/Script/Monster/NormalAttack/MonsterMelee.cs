using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMelee : Attack
{
    public float damage; // 공격 데미지
    public float attackDamage; // 공격 범위


    public override void ExecuteAttack()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, attackDamage);
        if (colliders.Length < 1.5 )
        {

        }
    }
}
