using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.AI;

public class WorkerFSM : MonsterFSM
{
    public GameObject target;
    public NavMeshAgent nav;

    public float dist; // ���Ϳ� �÷��̾� �Ÿ�
    public float attackDist = 1.7f;

    public int Shout = 0; // �Ҹ� ������ 1ȸ

    public float longAttackTime = 0; // ���Ÿ� ���� Ÿ��

    private void Start()
    {
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

            case MONSTER_STATE.LONGATTACK:
                UpdateLongAttack();
                break;

            case MONSTER_STATE.REACT:
                UpdateReact();
                break;

            case MONSTER_STATE.CUTSCENE:
                UpdateCutsene();
                break;

            case MONSTER_STATE.DIE:
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

            case MONSTER_STATE.LONGATTACK:
                SetLongAttack();
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
        animator.SetBool("IsAttack", false);
        animator.SetBool("IsShout", false);
        animator.SetBool("IsLongAttack", false);
    }
    void UpdateTracking() // ���� Ÿ�� ����
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, monsterStatus.sightRange);
       
        if( colliders.Length > 0 )
        {
            foreach(Collider col in colliders)
            {
                if (col.CompareTag("Player") && Shout == 0)
                {
                    target = col.gameObject;
                    ChangeState(MONSTER_STATE.REACT);
                }
                if (col.CompareTag("Player") && Shout == 1)
                {
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
    }

    void UpdateMove() // ���� ���� ����
    {
        longAttackTime += 1f * Time.deltaTime;
        dist = Vector3.Distance(transform.position, target.transform.position); // ���Ϳ� �÷��̾��� �Ÿ�
        nav.SetDestination(target.transform.position);
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f); // ���� ���� �����ϱ�

        if (colliders.Length > 0)
        {
            foreach (Collider col in colliders)
            {
                if (col.CompareTag("Player"))
                {
                    ChangeState(MONSTER_STATE.ATTACK);
                    break;
                }

                if( dist >= attackDist && longAttackTime >= 5f)
                {
                    ChangeState(MONSTER_STATE.LONGATTACK);
                    break;
                }
            }
        }
    }

    void SetAttack()
    {
        animator.SetBool("IsAttack", true);
        animator.SetBool("IsRun", false);
    }

    void UpdateAttack()
    {
        dist = Vector3.Distance(transform.position, target.transform.position);
        if(dist <= attackDist)
        {
            nav.ResetPath();
            this.transform.LookAt(target.transform.position);
            nav.velocity = Vector3.zero;
        }
        else if(dist > attackDist)
        {
            ChangeState(MONSTER_STATE.TRACKING);
        }
    }

    void SetLongAttack()
    {
        animator.SetBool("IsRun", false);
        animator.SetBool("IsIdle", false);
        animator.SetBool("IsLongAttack", true);
    }

    void UpdateLongAttack()
    {
        if(longAttackTime >= 5)
        {
            longAttackTime = 0f;
            transform.LookAt(target.transform.position);
            nav.ResetPath();
        }
        else if (longAttackTime <= 5)
        {
            StartCoroutine(WaitForLongAttack());
        }
    }

    void SetReact()
    {
        animator.SetBool("IsIdle", false);
        animator.SetBool("IsShout", true);
    }

    void UpdateReact()
    {
        if (Shout == 0)
        {
            transform.LookAt(target.transform.position);
            Shout += 1;
        }
        else if (Shout == 1)
        {
            StartCoroutine(WaitForEggAttackAnimation());
        }
    }

    void UpdateCutsene()
    {

    }

    void SetCutsene()
    {

    }

    void SetDie()
    {

    }

    IEnumerator WaitForEggAttackAnimation() // �Ҹ� ������ �ִϸ��̼� ���� �� 1�� ��
    {
        yield return new WaitForSeconds(2.2f);
        ChangeState(MONSTER_STATE.TRACKING);
    }
    IEnumerator WaitForLongAttack() // ���Ÿ� ���� �ִϸ��̼�
    {
        yield return new WaitForSeconds(1.2f);
        ChangeState(MONSTER_STATE.TRACKING);
    }
}
