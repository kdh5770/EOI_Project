using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NomalStateMarchine : MonsterFSM
{
    public GameObject target;
    public NavMeshAgent nav;

    public float attackDist;

    public Attack skill;
    public Attack melee;
    public Attack throwAttack;
    public bool isSkilled;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        monsterStatus = GetComponent<MonsterStatus>();
        nav = GetComponent<NavMeshAgent>();
        isSkilled = true;

        ChangeState(MONSTER_STATE.TRACKING);
    }

    private void Update()
    {

        switch (State)
        {
            case MONSTER_STATE.iDLE:
                break;

            case MONSTER_STATE.TRACKING:
                UpdateTracking();
                break;

            case MONSTER_STATE.MOVE:
                UpdateMove();
                break;

            case MONSTER_STATE.ATTACK:
                UpdateAttack();
                break;

            case MONSTER_STATE.REACT:
                UpdateReact();
                break;

            case MONSTER_STATE.CUTSCENE:
                UpdateCutsene();
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

            case MONSTER_STATE.MOVE:
                SetMove();
                break;

            case MONSTER_STATE.ATTACK:
                SetAttack();
                break;

            case MONSTER_STATE.REACT:
                SetReact();
                break;

            case MONSTER_STATE.CUTSCENE:
                SetCutsene();
                break;

            case MONSTER_STATE.DIE:
                SetDie();
                break;
        }
    }

    void SetIdle()
    {
        animator.SetBool("IsIdle", true);
    }

    void SetTracking()
    {
        animator.SetBool("IsIdle", true);
        animator.SetBool("IsRun", false);
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
                    ChangeState(MONSTER_STATE.MOVE);
                    break;
                }
            }
        }

    }

    void SetMove()
    {
        animator.SetBool("IsRun", true);
        animator.SetBool("IsIdle", false);
        nav.isStopped = false;
        nav.SetDestination(target.transform.position);

        //공격별 공격 범위 초기화
        if (isSkilled)
        {
            attackDist = skill.attackRange;

            return;
        }
        if (melee != null)
        {
            attackDist = melee.attackRange;
        }
        if (throwAttack != null)
        {
            attackDist = throwAttack.attackRange;
        }

    }

    void UpdateMove() // 공격 범위 감지
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, attackDist); // 공격 범위내 플레이어 감지

        if (colliders.Length > 0)
        {
            foreach (Collider col in colliders)
            {
                if (col.CompareTag("Player"))
                {
                    nav.ResetPath();
                    nav.isStopped = true;
                    nav.velocity = Vector3.zero;
                    ChangeState(MONSTER_STATE.ATTACK);
                    return;
                }
            }
        }
        ChangeState(MONSTER_STATE.TRACKING);
    }

    void SetAttack()
    {
        animator.SetBool("IsIdle", true);
        animator.SetBool("IsRun", false);

        if (isSkilled)
        {
            skill.ExecuteAttack(target);
            isSkilled = false;
            return;
        }
        if (melee != null)
            melee.ExecuteAttack(target);

        if (throwAttack != null)
            throwAttack.ExecuteAttack(target);

    }

    void UpdateAttack()
    {

    }


    void SetReact()
    {

    }

    void UpdateReact()
    {

    }

    void UpdateCutsene()
    {

    }

    void SetCutsene()
    {

    }

    void SetDie()
    {
        animator.SetTrigger("IsDead");
    }

    void UpdateDie()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            Destroy(this.gameObject);
        }
    }
    public override void ChangeReactionState(REACT_TYPE _state)
    {
        throw new System.NotImplementedException();
    }
}
