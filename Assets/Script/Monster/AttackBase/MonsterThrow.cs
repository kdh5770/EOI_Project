using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterThrow : Attack
{
    public GameObject throwPre;
    public GameObject shootPos;

    public GameObject preObj;

    public float impulsPow;
    public override void ExecuteAttack(GameObject _target)
    {
        Vector3 direction = (_target.transform.position - shootPos.transform.position).normalized;
        preObj = Instantiate(throwPre, shootPos.transform.position, Quaternion.identity);
        preObj.GetComponent<ThorwObject>().SetDamage(damage);
        preObj.GetComponent<Rigidbody>().AddForce(direction * impulsPow, ForceMode.Impulse);
    }
}
