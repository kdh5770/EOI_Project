using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMelee : Attack
{
    public float damage; // ���� ������
    public float attackDamage; // ���� ����


    public override void ExecuteAttack()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, attackDamage);
        if (colliders.Length < 1.5 )
        {

        }
    }
}
