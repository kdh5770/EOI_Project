using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill_A : MonsterSkill
{
    public GameObject firePosition;
    public GameObject bulletPrefab; // 탄 프리팹
    public int numberOfBullets = 8; // 한 번에 날아가는 탄의 개수
    public int loopMaxCount = 2;
    public int loopCurCount = 0;
    public float projectileSpeed = 3f; // 탄 속도
    public float projectileLifetime = 5f; // 탄이 생성되어 있는 시간
    public float gravity = -9.8f; // 중력 가속도
    

    public override void ApplyReaction(GameObject target)
    {
       
    }

    public override void ApplySkillEffect(GameObject target)
    {
        
    }

    public override void ExecuteAttack(GameObject _target)
    {
        target = _target;
        animationEvent.ActionAttack += ActionAttack;
        animator.SetTrigger("IsSpout2");
    }

    public override void ActionAttack()
    {
        Vector3 spawnPosition = new Vector3(0, 7, 0); // x, y, z는 좌표 값입니다.

        for (int i = 0; i < numberOfBullets; i++)
        {
            // 랜덤한 방향으로 탄을 발사
            Vector3 randomDirection = Random.onUnitSphere.normalized;
            GameObject projectile = Instantiate(bulletPrefab, firePosition.transform.position, Quaternion.identity);

            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

            //// 초기 속도 설정
            projectileRb.velocity = randomDirection * projectileSpeed;

            //// 중력 적용
            projectileRb.useGravity = true;

            // 일정 시간이 지난 후에 탄을 제거
            Destroy(projectile, projectileLifetime);
        }

        if(++loopCurCount >= loopMaxCount)
        {
            animationEvent.ActionAttack -= ActionAttack;
            animator.SetTrigger("isStopLoop");
            loopCurCount = 0;
        }
    }
}