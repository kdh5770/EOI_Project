using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatcherThrow : Attack
{
    [Header("발사체 프리팹")]
    public GameObject BulletEftPre;
    [Header("발사 위치")]
    public Transform BulletTf;
    [Header("생성된 발사체")]
    public GameObject BulletEft;
    private Vector3 direction;

    public override void ExecuteAttack(GameObject _target)
    {
        animationEvent.ActionAttack += ActionAttack;
        target = _target;

        // 타겟 방향 계산
        Vector3 targetPosition = target.transform.position;
        targetPosition.y += 1f; // 높이를 1만큼 올립니다.

        Vector3 targetDirection = (targetPosition - BulletTf.position).normalized;

        // 발사체 방향 계산 (타겟 위치 - 발사 위치)
        direction = targetDirection;
        transform.LookAt(targetPosition);

        animator.SetTrigger("isThrow");
    }

    public override void ActionAttack()
    {
        // 발사체 생성 후 방향 설정
        BulletEft = Instantiate(BulletEftPre, BulletTf.transform.position, Quaternion.LookRotation(direction));

        // 발사체에 힘을 가하여 이동
        BulletEft.GetComponent<Rigidbody>().velocity = direction * 30f; // 타겟 방향으로 발사체를 이동시킵니다.
        Destroy(BulletEft, 5f);
        animationEvent.ActionAttack -= ActionAttack;
    }
}