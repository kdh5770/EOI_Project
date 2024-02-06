using System.Collections;
using UnityEngine;

public class BossEnergy : MonsterSkill
{
    [Header("������ ��ų")]
    public GameObject energyBall;
    [Header("Ÿ��")]
    public GameObject towerPre1;
    public GameObject towerPre2;
    public GameObject towerPre3;
    [Header("����")]
    public GameObject shield1;
    public GameObject shield2;
    public GameObject shield3;
    [Header("��ġ")]
    public Transform shieldTf;
    public Transform preTf;
    public Transform tower1;
    public Transform tower2;
    public Transform tower3;
    [Header("������ ����")]
    public GameObject _shield1;
    public GameObject _shield2;
    public GameObject _shield3;

    public GameObject preObj;

    public int loopMaxCount = 23;
    public int loopCurCount = 0;

    public float neutralizeTime = 0f; // ����ȭ �ð�
    public WormFSM fsm;

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
        animationEvent.ActionAttack += ActionAttack;
        animator.SetTrigger("IsEnergy");
    }
    public override void ActionAttack()
    {
        Energy();
        if (_shield1 == null && _shield2 == null && _shield3 == null)
        {
            Destroy(preObj);
            animationEvent.ActionAttack -= ActionAttack;
            animator.SetTrigger("isStopLoop2");
            StartCoroutine(NeutralizeTime());
            if (neutralizeTime >= 5)
            {
                animator.SetTrigger("isStopLoop");
                //fsm.ChangeState(MONSTER_STATE.TRACKING);
            }
        }
        if (++loopCurCount >= loopMaxCount)
        {
            animationEvent.ActionAttack -= ActionAttack;
            animator.SetTrigger("isStopLoop");
            loopCurCount = 0;
        }
    }

    public void Energy()
    {
        if (preObj == null)
        {
            preObj = Instantiate(energyBall, preTf.position, Quaternion.identity);
            _shield1 = Instantiate(shield1, shieldTf.transform.position, Quaternion.identity);
            _shield2 = Instantiate(shield2, shieldTf.transform.position, Quaternion.identity);
            _shield3 = Instantiate(shield3, shieldTf.transform.position, Quaternion.identity);
            Instantiate(towerPre1, tower1.position, Quaternion.identity);
            Instantiate(towerPre2, tower2.position, Quaternion.identity);
            Instantiate(towerPre3, tower3.position, Quaternion.identity);
        }
    }
    public void ShieldDestroy()
    {
        if(_shield1 == null && _shield2 == null && _shield3 == null)
        {
            Destroy(preObj);
            animator.SetTrigger("isStopLoop2");
        }
    }

    IEnumerator NeutralizeTime()
    {
        while (neutralizeTime <= 5)
        {
            neutralizeTime += Time.deltaTime;
            yield return null;
        }
    }
}
