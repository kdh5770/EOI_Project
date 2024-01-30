using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant_Skill_A : MonsterSkill
{
    // �� ĥ �� ���� �ݰ� ���� �������� �˼� Ƣ��ͼ� ����
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
        Debug.Log("�� ġ�� ���� �÷��̾� ��ġ�� ������ �˼� ���ͼ� ����");
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
