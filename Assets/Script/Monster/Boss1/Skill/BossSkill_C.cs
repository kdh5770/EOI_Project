using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill_C : MonsterSkill
{
    [Header("보스가 생성한 벽")]
    public GameObject objectPrefab; // 생성할 오브젝트 프리팹
    public Transform bossTransform; // 보스의 Transform
    public float spawnRadius = 15f; // 생성 반경
    public float spawnInterval = 2f; // 생성 간격


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
        // 타겟이 보고 있는 방향 벡터
        Vector3 targetForward = target.transform.forward;

        // 랜덤한 위치 생성 (타겟 주변)
        Vector3 randomPointNearTarget = GetRandomPointNearTarget(target.transform.position, spawnRadius);

        // 오브젝트를 타겟이 보고 있는 방향으로 이동
        Vector3 spawnPosition = randomPointNearTarget + targetForward * spawnRadius;

        // 오브젝트 생성
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
