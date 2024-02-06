using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill_C : MonsterSkill
{
    [Header("������ ������ ��")]
    public GameObject objectPrefab; // ������ ������Ʈ ������
    public Transform bossTransform; // ������ Transform
    public float spawnRadius = 15f; // ���� �ݰ�
    public float spawnInterval = 2f; // ���� ����


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
        animator.SetTrigger("IsWall");
    }

    public override void ActionAttack()
    {
        // Ÿ���� ���� �ִ� ���� ����
        Vector3 targetForward = target.transform.forward;

        // ������ ��ġ ���� (Ÿ�� �ֺ�)
        Vector3 randomPointNearTarget = GetRandomPointNearTarget(target.transform.position, spawnRadius);

        // ������Ʈ�� Ÿ���� ���� �ִ� �������� �̵�
        Vector3 spawnPosition = randomPointNearTarget + targetForward * spawnRadius;

        // ������Ʈ ����
        GameObject spawnedObject = Instantiate(objectPrefab, randomPointNearTarget, Quaternion.identity);

        animationEvent.ActionAttack -= ActionAttack;
    }

    Vector3 GetRandomPointNearTarget(Vector3 center, float radius)
    {
        Vector2 randomPointOnCircle = Random.insideUnitCircle * radius;
        Vector3 randomPointNearTarget = new Vector3(center.x + randomPointOnCircle.x, center.y, center.z + randomPointOnCircle.y);
        return randomPointNearTarget;
    }
}
