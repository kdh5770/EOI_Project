using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossSkill_B : MonsterSkill
{
    public GameObject spoutEffect;
    public Transform firePosition;
    private GameObject preObj;

    public int loopMaxCount = 23;
    public int loopCurCount = 0;

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

        Vector3 direction = (target.transform.position - firePosition.transform.position).normalized;
        direction.y = 0f;//
        transform.root.rotation = Quaternion.LookRotation(direction);

        animator.SetTrigger("IsSpout");
    }
    public override void ActionAttack()
    {
        if (loopCurCount == 0)
        {
            spoutEffect.transform.position = firePosition.transform.position;
            spoutEffect.SetActive(true);
        }

        if (++loopCurCount >= loopMaxCount)
        {
            animationEvent.ActionAttack -= ActionAttack;
            animator.SetTrigger("isStopLoop");
            loopCurCount = 0;

            spoutEffect.SetActive(false);
        }
    }

}
