using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerShoot : Attack, ISkillEffect
{
    public GameObject egg;
    public int encounter = 10;

    public void ApplyReaction(GameObject target) // 리액션 효과 (넉백)
    {
        Debug.Log("리액션 효과");
    }

    public void ApplySkillEffect(GameObject target) // 스킬 효과
    {
        Debug.Log("스킬 효과");
    }

    public override void ExecuteAttack(GameObject _target) // 공격 실행
    {
        transform.LookAt(_target.transform.position);

        egg.GetComponent<ThorwObject>().SetDamage(10);
        Rigidbody EGG = egg.GetComponent<Rigidbody>();
        EGG.AddForce(transform.forward * encounter, ForceMode.Impulse);
        egg.transform.SetParent(null);
    }
}
