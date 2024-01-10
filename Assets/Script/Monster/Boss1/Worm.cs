using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class Worm : MonsterFSM
{
    public GameObject target;

    public GameObject bullet;
    public Transform firePos;
    public int encounter = 10;

    public GameObject spoutEft;
    public float spoutTime = 0f;

    public float attackTime = 0; // 공격 딜레이
    public int spwanCount = 0;
    public int attackType = 0; // 공격 타입

    public Attack throwAttack;

    public float rotationSpeed = 2f;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        monsterStatus = GetComponent<MonsterStatus>();
        ChangeState(MONSTER_STATE.TRACKING);
    }


    private void Update()
    {
        switch (State)
        {

            case MONSTER_STATE.iDLE:
                UpdateIdle();
                break;

            case MONSTER_STATE.TRACKING:
                UpdateTracking();
                break;

            case MONSTER_STATE.ATTACK:
                UpdateAttack();
                break;

            case MONSTER_STATE.REACT:
                UpdateReact();
                break;

            case MONSTER_STATE.DIE:
                UpdateDie();
                break;
        }
    }
    public override void ChangeState(MONSTER_STATE _state)
    {
        State = _state;

        switch (State)
        {
            case MONSTER_STATE.iDLE:
                SetIdle();
                break;

            case MONSTER_STATE.TRACKING:
                SetTracking();
                break;

            case MONSTER_STATE.ATTACK:
                SetAttack();
                break;

            case MONSTER_STATE.REACT:
                SetReact();
                break;

            case MONSTER_STATE.DIE:
                SetDie();
                break;
        }
    }
    void SetIdle()
    {
        animator.SetTrigger("IsSpawn");
        animator.SetBool("IsIdle", true);
        animator.SetBool("IsLongAttack", false);
        animator.SetBool("IsSpout", false);
    }

    void UpdateIdle()
    {
        attackTime += Time.deltaTime;
        gameObject.transform.LookAt(target.transform.position);

        if (attackTime >= 5)
        {
            attackType += 1;
            ChangeState(MONSTER_STATE.ATTACK);
        }
    }

    void SetTracking()
    {
    }
    void UpdateTracking() // 추적 타겟 감지
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, monsterStatus.sightRange);

        if (colliders.Length > 0)
        {
            foreach (Collider col in colliders)
            {
                if (col.CompareTag("Player"))
                {
                    target = col.gameObject;
                    ChangeState(MONSTER_STATE.iDLE);
                    break;
                }
            }
        }
    }

    void SetAttack()
    {
        if (attackType % 3 == 0)
        {
            animator.SetBool("IsSpout", true);
            animator.SetBool("IsIdle", false);
        }
        else
        {
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsLongAttack", true);
        }
    }

    public float skillTime = 0f;
    void UpdateAttack()
    {
        //gameObject.transform.LookAt(target.transform.position);
        skillTime += Time.deltaTime;

        if (attackTime >= 5 && skillTime >= 5f && attackType % 3 == 0)
        {
            skillTime = 0f;
            attackTime = 0;
            ChangeState(MONSTER_STATE.iDLE);
        }
        else if (attackType % 3 != 0 && attackTime >= 5)
        {
            skillTime = 0f;
            attackTime = 0;
            ChangeState(MONSTER_STATE.iDLE);
        }
    }

    void UpdateDie()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            Destroy(this.gameObject);
        }
    }

    void SetDie()
    {
        animator.SetTrigger("IsDescend");
    }

    void UpdateReact()
    {

    }

    void SetReact()
    {

    }




    /// <summary>
    /// /////////////////////////////////////////////////////////////////////////
    /// </summary>

    public void Idle()
    {
        animator.SetBool("IsSpwan", false);
        animator.SetBool("IsIdle", true);
    }

    public override void ChangeReactionState(REACT_TYPE _state)
    {
        throw new System.NotImplementedException();
    }

    public void attackEgg()
    {
        throwAttack.ExecuteAttack(target);
    }

    public void attackSpout()
    {
        Vector3 direction = (target.transform.position - firePos.transform.position).normalized;
        testobj = Instantiate(spoutEft, firePos.position, Quaternion.LookRotation(direction));
        if(target != null)
        {
            StartCoroutine(test());
        }
    }

    public GameObject testobj;
    IEnumerator test() // 타겟을 쳐다보게
    {
        float time = 0f;
        while (time <= 5)
        {
            Vector3 direction = target.transform.position - transform.position;
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);

            // 부드러운 회전을 위해 Slerp 사용
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.deltaTime * rotationSpeed);

            testobj.transform.position = firePos.transform.position;
            testobj.transform.rotation = firePos.transform.rotation;

            Vector3 fireposdirection = (target.transform.position - firePos.transform.position).normalized;
            Quaternion firePostoRotation = Quaternion.LookRotation(fireposdirection, Vector3.up);
            firePos.transform.rotation = Quaternion.Slerp(firePos.transform.rotation, firePostoRotation, Time.deltaTime * rotationSpeed);

            yield return null;
            time+= Time.deltaTime;
        }
    }
}
