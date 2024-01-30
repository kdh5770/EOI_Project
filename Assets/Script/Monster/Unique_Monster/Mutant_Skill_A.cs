using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant_Skill_A : MonsterSkill
{
    // 땅 칠 때 몬스터 반경 내에 랜덤으로 촉수 튀어나와서 공격
    [SerializeField]
    private GameObject SkillPrefab;
    public float radius = 10f;
    public int numberOfSkills = 20;
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
        animator.SetTrigger("IsSkillA");
        Debug.Log("땅 치는 순간 플레이어 위치에 땅에서 촉수 나와서 공격");
    }
    public override void ActionAttack()
    {
        Vector3 monsterPosition = transform.position;
        for (int i = 0; i < numberOfSkills; i++)
        {
            Vector2 randomOffset = Random.insideUnitCircle * radius;
            Vector3 randomPosition = new Vector3(monsterPosition.x + randomOffset.x, monsterPosition.y, monsterPosition.z + randomOffset.y);
            Instantiate(SkillPrefab, randomPosition, Quaternion.identity);
        }
        animationEvent.ActionAttack -= ActionAttack;
    }
}
