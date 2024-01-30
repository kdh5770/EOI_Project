using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant_Skill_C : MonsterSkill
{
    // 어깨 가시 공격(원거리)
    [SerializeField]
    private Transform[] shootpositions;
    [SerializeField]
    private GameObject shootobj;

    public float objspeed = 10f;

    Vector3 direction;

    public override void ApplyReaction(GameObject target)
    {
        throw new System.NotImplementedException();
    }

    public override void ApplySkillEffect(GameObject target)
    {
        throw new System.NotImplementedException();
    }

    public override void ExecuteAttack(GameObject _target)
    {
        target = _target;
        animationEvent.ActionAttack += ActionAttack;
        direction = (target.transform.position - transform.position).normalized;
        animator.SetTrigger("IsSkillC");
        Debug.Log("어깨에서 가시같은거 던짐");
    }
    public override void ActionAttack()
    {
        for (int i = 0; i < shootpositions.Length; i++)
        {
            shootobj = Instantiate(shootobj, shootpositions[i].position, Quaternion.LookRotation(direction));
            shootobj.GetComponent<Rigidbody>().AddForce(direction * objspeed, ForceMode.Impulse);
        }

        animationEvent.ActionAttack -= ActionAttack;
    }
}
