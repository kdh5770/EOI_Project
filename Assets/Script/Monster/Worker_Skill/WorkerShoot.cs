using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerShoot : MonsterSkill
{
    public GameObject egg;
    public int encounter = 10;

    public override void ApplyReaction(GameObject target) // 리액션 효과 (넉백 같은거)
    {
        Debug.Log("리액션 효과");
    }

    public override void ApplySkillEffect(GameObject target) // 스킬 효과
    {
        Debug.Log("스킬 효과");
    }

    public override void ExecuteAttack(GameObject _target) // 공격 실행
    {
        animationEvent.ActionAttack += ActionAttack;

        target = _target;
        animator.SetTrigger("IsShootSkill");
        egg.GetComponent<ThorwObject>().SetDamage(damage);
        transform.LookAt(target.transform.position);
    }

    public override void ActionAttack()
    {
        Rigidbody EGG = egg.GetComponent<Rigidbody>();
        EGG.AddForce(transform.forward * encounter, ForceMode.Impulse);
        egg.transform.SetParent(null);

        animationEvent.ActionAttack -= ActionAttack;
    }

}
