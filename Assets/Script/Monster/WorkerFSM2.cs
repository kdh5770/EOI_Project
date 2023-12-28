using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.AI;

public class WorkerFSM2 : MonsterFSM
{
    public GameObject target;
    public NavMeshAgent nav;

    public float dist; // 몬스터와 플레이어 거리
    public float attackDist = 3f;

    public int eggAttack = 0; // 알 던지는 공격 1회

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
        animator.SetBool("IsEggAttack", false);
    }
    void UpdateTracking() // 추적 타겟 감지
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, monsterStatus.sightRange);

        if (colliders.Length > 0)
        {
            foreach (Collider col in colliders)
            {
                if(col.CompareTag("Player") && eggAttack == 0)
                {
                    target = col.gameObject;
                    ChangeState(MONSTER_STATE.REACT);
                }
                if (col.CompareTag("Player") && eggAttack == 1)
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

    void UpdateMove() // 공격 범위 감지
    {
        nav.SetDestination(target.transform.position);
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f); // 공격 범위 지정하기

        if (colliders.Length > 0)
        {
            foreach (Collider col in colliders)
            {
                if (col.CompareTag("Player"))
                {
                    ChangeState(MONSTER_STATE.ATTACK);
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
        if (dist <= attackDist)
        {
            nav.ResetPath();
            nav.velocity = Vector3.zero;
        }
        else if (dist > attackDist)
        {
            ChangeState(MONSTER_STATE.TRACKING);
        }
    }

    void SetReact()
    {
        animator.SetBool("IsIdle", false);
        animator.SetBool("IsEggAttack", true);

    }

    void UpdateReact()
    {
        if (eggAttack == 0)
        {
            transform.LookAt(target.transform.position);
            eggAttack += 1;
        }
        else if (eggAttack == 1)
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

    IEnumerator WaitForEggAttackAnimation() // 알 던지기 애니메이션 실행 후 1초 뒤
    {
        yield return new WaitForSeconds(1);
        ChangeState(MONSTER_STATE.TRACKING);
    }
}
