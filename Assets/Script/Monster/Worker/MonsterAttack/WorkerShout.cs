using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorkerShout : Attack, ISkillEffect
{

    public Transform qte;
    public GameObject target;
    public GameObject Worker;

    public void ApplyReaction(GameObject target) // 리액션 효과 (넉백)
    {
        Debug.Log("리액션 효과");
    }

    public void ApplySkillEffect(GameObject target) // 스킬 효과
    {
        Debug.Log("스킬 효과");
    }

    public override void ExecuteAttack() // 공격 실행
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 11f); // 공격 범위 지정하기

        if (colliders.Length > 0)
        {
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Player"))
                {
                    animator.SetTrigger("IsShoutSkill");
                    Debug.Log("샤우팅");
                    break;
                }
            }
        }
    }
}
