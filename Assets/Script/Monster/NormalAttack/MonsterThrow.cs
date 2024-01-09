using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterThrow : Attack
{
    public GameObject throwPre;
    public GameObject shootPos;

    public float damage; // ���� ������
    public float attackRange; // ���� ����
    public GameObject preObj;

    public float impulsPow;
    public override void ExecuteAttack(GameObject _target)
    {
        preObj = Instantiate(throwPre, shootPos.transform.position, Quaternion.LookRotation(_target.transform.position));
        preObj.GetComponent<ThorwObject>().SetDamage(damage);
        preObj.GetComponent<Rigidbody>().AddForce(transform.forward * impulsPow);
    }
}
