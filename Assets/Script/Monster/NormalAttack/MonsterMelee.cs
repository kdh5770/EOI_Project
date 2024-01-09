using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMelee : Attack
{
    public float damage; // 공격 데미지
    public float attackRange; // 공격 범위


    public override void ExecuteAttack(GameObject _target)
    {
        transform.LookAt(_target.transform.position);
        _target.GetComponent<CharacterHealth>().TakeDamage(damage);

    }
}
