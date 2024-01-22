using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterThrow : Attack
{
    public GameObject throwPre;
    public GameObject shootPos;
    public float impulsPow;

    private GameObject preObj;
    Vector3 direction;
    public override void ExecuteAttack(GameObject _target)
    {
        animationEvent.ActionAttack += ActionAttack;

        target = _target;
        direction = (target.transform.position - shootPos.transform.position).normalized;
        preObj = Instantiate(throwPre, shootPos.transform.position, Quaternion.identity);
        preObj.GetComponent<ThorwObject>().SetDamage(damage);
    }

    public override void ActionAttack()
    {
        preObj.GetComponent<Rigidbody>().AddForce(direction * impulsPow, ForceMode.Impulse);

        animationEvent.ActionAttack -= ActionAttack;
    }

}
