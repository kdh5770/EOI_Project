using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unique_FSM : MonsterFSM
{
    public GameObject target;
    NavMeshAgent nav;
    Unique_Health unique_Health;
    private Unique_SkillController skillController;


    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        unique_Health = GetComponent<Unique_Health>();
        skillController = GetComponentInChildren<Unique_SkillController>();
        nav = GetComponent<NavMeshAgent>();

        ChangeState(MONSTER_STATE.TRACKING);
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
        Collider[] colliders = Physics.OverlapSphere(transform.position, unique_Health.sightRange);

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
        animator.SetBool("IsIdle", false);
        animator.SetBool("IsRun", true);
        nav.isStopped = false;
        nav.SetDestination(target.transform.position);
    }

    void UpdateMove() // 공격 범위 감지
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 2); // 공격 범위내 플레이어 감지

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
        skillController.SetAttackState(target);
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

    }
    public override void ChangeReactionState(REACT_TYPE _state)
    {
        throw new System.NotImplementedException();
    }
}
