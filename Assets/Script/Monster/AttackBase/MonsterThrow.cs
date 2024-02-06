using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
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
        //direction.y = 0f;//
        transform.root.rotation = Quaternion.LookRotation(direction);

        animator.SetTrigger("isThrow");
    }

    public override void ActionAttack()
    {
        preObj = Instantiate(throwPre, shootPos.transform.position, Quaternion.LookRotation(direction));
        preObj.GetComponent<ThorwObject>().SetDamage(damage);
        preObj.GetComponent<Rigidbody>().AddForce(direction * impulsPow, ForceMode.Impulse);

        animationEvent.ActionAttack -= ActionAttack;
    }

}
