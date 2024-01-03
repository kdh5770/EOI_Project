using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NomalStateMarchine : MonsterFSM
{
    public GameObject target;
    public NavMeshAgent nav;

    public float dist; // 몬스터와 플레이어 거리
    public float attackDist = 1.7f;

    public int Shout = 0; // 소리 지르기 1회

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
        animator.SetBool("IsMelee", false);
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
    }

    void UpdateMove() // 공격 범위 감지
    {
        nav.SetDestination(target.transform.position);
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f); // 공격 범위 지정하기

        Debug.Log(colliders.Length);
        if (colliders.Length > 0)
        {
            Debug.Log("2");
            foreach (Collider col in colliders)
            {
                if (col.CompareTag("Player"))
                {
                    Debug.Log("3");
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
        skill.ExecuteAttack();
    }

    float testtime = 0;
    void UpdateAttack()
    {
        testtime += Time.deltaTime;
        if(testtime >= 1f)
        {
            testtime = 0;
            ChangeState(MONSTER_STATE.TRACKING);
        }
    }

    void SetLongAttack()
    {

    }

    void UpdateLongAttack()
    {

    }

    void SetReact()
    {
        //animator.SetBool("IsIdle", false);
        //animator.SetBool("IsShout", true);
    }

    void UpdateReact()
    {
        //if (Shout == 0)
        //{
        //    transform.LookAt(target.transform.position);
        //    Shout += 1;
        //}
        //else if (Shout == 1)
        //{
        //    StartCoroutine(WaitForEggAttackAnimation());
        //}
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

    //IEnumerator WaitForEggAttackAnimation() // 소리 지르기 애니메이션 실행 후 1초 뒤
    //{
    //    yield return new WaitForSeconds(2.2f);
    //    ChangeState(MONSTER_STATE.TRACKING);
    //}
    //IEnumerator WaitForLongAttack() // 원거리 공격 애니메이션
    //{
    //    yield return new WaitForSeconds(1.2f);
    //    ChangeState(MONSTER_STATE.TRACKING);
    //}

    public override void ChangeReactionState(REACT_TYPE _state)
    {
        throw new System.NotImplementedException();
    }
}
