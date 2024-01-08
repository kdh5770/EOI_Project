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

    public float attackTime = 0;
    public int spwanCount = 0;


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
    }

    void UpdateIdle()
    {
        attackTime += Time.deltaTime;
        gameObject.transform.LookAt(target.transform.position);

        if (attackTime >= 5)
        {
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
        animator.SetBool("IsIdle", false);
        animator.SetBool("IsLongAttack", true);
    }

    void UpdateAttack()
    {
        gameObject.transform.LookAt(target.transform.position);

        if (attackTime >= 5)
        {
            attackTime = 0;
            attackEgg();
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
        animator.SetTrigger("IsDead");
    }

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
        Vector3 direction = (target.transform.position - firePos.position).normalized;
        GameObject preObj = Instantiate(bullet, firePos.position, Quaternion.identity);
        preObj.GetComponent<Rigidbody>().AddForce(direction * encounter, ForceMode.Impulse);
    }
}
