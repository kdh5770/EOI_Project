using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NomalStateMarchine : MonsterFSM
{
    public GameObject target;
    public NavMeshAgent nav;

    public float dist; // ���Ϳ� �÷��̾� �Ÿ�
    public float attackDist = 1.5f;

    public int Shout = 0; // �Ҹ� ������ 1ȸ

    public Attack skill;
    public Attack melee;
    public Attack throwAttack;

    public bool isSkill;

    private void Start()
    {
        isSkill = true;
        animator = GetComponentInChildren<Animator>();
        monsterStatus = GetComponent<MonsterStatus>();
        nav = GetComponent<NavMeshAgent>();

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
        animator.SetBool("IsMelee", false);
        animator.SetBool("IsRun", false);
    }
    void UpdateTracking() // ���� Ÿ�� ����
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
    }

    void UpdateMove() // ���� ���� ����
    {
        dist = Vector3.Distance(transform.position, target.transform.position);
        nav.SetDestination(target.transform.position);
        Collider[] colliders = Physics.OverlapSphere(transform.position, 7f); // ���� ���� �����ϱ�

        Debug.Log(colliders.Length);
        if (colliders.Length > 0)
        {
            foreach (Collider col in colliders)
            {
                if (col.CompareTag("Player"))
                {
                    nav.ResetPath();
                    nav.isStopped = true;
                    ChangeState(MONSTER_STATE.ATTACK);
                    break;
                }
            }
        }
    }

    void SetAttack()
    {
        animator.SetBool("IsIdle", true);
        animator.SetBool("IsRun", false);

        if (skill != null)
        {
            skill.ExecuteAttack(target);
            skill = null;
            return;
        }
        if (melee != null)
            melee.ExecuteAttack(target);

        if (throwAttack != null)
            throwAttack.ExecuteAttack(target);

    }

    void UpdateAttack()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsTag("attack"))
        {
            ChangeState(MONSTER_STATE.TRACKING);
        }
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
