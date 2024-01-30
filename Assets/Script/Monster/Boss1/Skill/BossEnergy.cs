using UnityEngine;

public class BossEnergy : MonsterSkill
{
    public GameObject energyBall;
    public GameObject towerPre1;
    public GameObject towerPre2;
    public GameObject towerPre3;
    public GameObject shield1;
    public GameObject shield2;
    public GameObject shield3;

    public Transform shieldTf;
    public Transform preTf;
    public Transform tower1;
    public Transform tower2;
    public Transform tower3;

    public GameObject preObj;

    public int loopMaxCount = 23;
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
        animationEvent.ActionAttack += ActionAttack;
        animator.SetTrigger("IsEnergy");
        ShieldDestroy();
    }
    public override void ActionAttack()
    {
        Energy();
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
            Instantiate(shield1, shieldTf.transform.position, Quaternion.identity);
            Instantiate(shield2, shieldTf.transform.position, Quaternion.identity);
            Instantiate(shield3, shieldTf.transform.position, Quaternion.identity);
            Instantiate(towerPre1, tower1.position, Quaternion.identity);
            Instantiate(towerPre2, tower2.position, Quaternion.identity);
            Instantiate(towerPre3, tower3.position, Quaternion.identity);
        }
    }
    public void ShieldDestroy()
    {
        if(shield1 == null && shield2 == null && shield3 == null)
        {
            animator.SetTrigger("isStopLoop2");
        }
    }
    
}
