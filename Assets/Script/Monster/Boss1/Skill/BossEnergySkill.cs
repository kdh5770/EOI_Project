using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnergySkill : MonsterSkill
{
    public GameObject pre;
    public Transform tf;

    public GameObject preObj;

    public override void ActionAttack()
    {
        throw new System.NotImplementedException();
    }

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
        animator.SetTrigger("IsEnergy");
        if (preObj == null)
        {
            preObj = Instantiate(pre, tf.position, Quaternion.identity);
        }
    }

    
}
