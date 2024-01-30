using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant_Skill_D : MonsterSkill
{
    // 샤우팅하면서 주위에 잡몹 소환
    [SerializeField]
    private Transform[] spawnpositions; // 스폰할 위치
    [SerializeField]
    private GameObject spawnmob; // 스폰몬스터 프리팹
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

        transform.LookAt(_target.transform.position);
        animator.SetTrigger("IsSkillD");
    }
    public override void ActionAttack()
    {
        for(int i=0;  i<spawnpositions.Length; i++) 
        {
            Instantiate(spawnmob, spawnpositions[i].position, Quaternion.identity);
        }
        animationEvent.ActionAttack -= ActionAttack;
    }
}
