using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant_Skill_D : MonsterSkill
{
    // �������ϸ鼭 ������ ��� ��ȯ
    [SerializeField]
    private Transform[] spawnpositions; // ������ ��ġ
    [SerializeField]
    private GameObject spawnmob; // �������� ������
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
