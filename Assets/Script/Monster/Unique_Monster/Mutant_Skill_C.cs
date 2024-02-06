using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant_Skill_C : MonsterSkill
{
    // 어깨 가시 공격(원거리)
    [SerializeField]
    private Transform[] shootpositions;
    [SerializeField]
    private GameObject shootobjprefab;
    private List<GameObject> shootobjs = new List<GameObject>();
    private float objdestroyTime=5f;


    public float objspeed = 10f;

    Vector3 direction;

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
        direction = (target.transform.position - transform.position).normalized;
        animator.SetTrigger("IsSkillC");
    }
    public override void ActionAttack()
    {
        for (int i = 0; i < shootpositions.Length; i++)
        {
            GameObject shootObj = Instantiate(shootobjprefab, shootpositions[i].position, Quaternion.LookRotation(direction));
            shootObj.GetComponent<Rigidbody>().AddForce(direction * objspeed, ForceMode.Impulse);
            shootobjs.Add(shootObj);
            Invoke("DestoryObj", objdestroyTime);
        }

        animationEvent.ActionAttack -= ActionAttack;
    }

    void DestoryObj()
    {
        foreach(var obj in shootobjs)
        {
            Destroy(obj);
        }
        shootobjs.Clear();
    }
}
