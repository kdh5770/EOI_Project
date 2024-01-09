using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMelee : Attack
{
    public float damage; // ���� ������
    public float attackRange; // ���� ����


    public override void ExecuteAttack(GameObject _target)
    {
        transform.LookAt(_target.transform.position);
        _target.GetComponent<CharacterHealth>().TakeDamage(damage);

    }
}
