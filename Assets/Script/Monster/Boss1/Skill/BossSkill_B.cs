using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossSkill_B : MonsterSkill
{
    public GameObject spoutEffect;
    public Transform firePosition;
    private GameObject preObj;

    public int loopMaxCount = 10;
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

        //preObj = Instantiate(spoutEffect, firePosition.position, firePosition.transform.rotation);
        //// 플레이어 방향으로 회전시키기
        //Vector3 playerDirection = (target.transform.position - firePosition.position).normalized;
        //Quaternion toRotation = Quaternion.LookRotation(playerDirection, Vector3.up);

        //// 회전 각도를 설정
        //float rotationAngle = 20f;

        //// y축으로 회전시키기 (플레이어 방향을 기준으로 회전)
        //Vector3 eulerRotation = new Vector3(rotationAngle, toRotation.eulerAngles.y, 0f);
        //preObj.transform.eulerAngles = eulerRotation;

        if (++loopCurCount >= loopMaxCount)
        {
            animationEvent.ActionAttack -= ActionAttack;
            animator.SetTrigger("isStopLoop");
            loopCurCount = 0;

            spoutEffect.SetActive(false);
        }
    }

}
