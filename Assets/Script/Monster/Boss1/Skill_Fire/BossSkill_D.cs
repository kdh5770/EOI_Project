using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill_D : MonsterSkill
{
    public GameObject fire_pre;
    public Transform fire_pos;

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
        target = _target;
    }

    public void BossSkill_Fire()
    {

        preObj = Instantiate(fire_pre, fire_pos.position, fire_pos.transform.rotation);
        // 플레이어 방향으로 회전시키기
        Vector3 playerDirection = (target.transform.position - fire_pos.position).normalized;
        Quaternion toRotation = Quaternion.LookRotation(playerDirection, Vector3.up);

        // 회전 각도를 설정
        float rotationAngle = 20f;

        // y축으로 회전시키기 (플레이어 방향을 기준으로 회전)
        Vector3 eulerRotation = new Vector3(rotationAngle, toRotation.eulerAngles.y, 0f);
        preObj.transform.eulerAngles = eulerRotation;
    }
}
