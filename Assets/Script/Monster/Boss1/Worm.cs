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
        animator.SetBool("IsSpout2", false);
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
        bool skill = Random.Range(0, 2) == 0;

        if (attackType % 3 == 0 && skill)
        {
            animator.SetBool("IsSpout", true);
            animator.SetBool("IsIdle", false);
        }
        else if (attackType % 3 == 0 && !skill)
        {
            animator.SetBool("IsSpout2", true);
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

    float time = 0f;
    void UpdateDie()
    {
        time += Time.deltaTime;
        if(time >= 3)
        {
            Destroy(gameObject);
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
        testobj = Instantiate(spoutEft, firePos.position, Quaternion.identity);

        // 플레이어 방향으로 회전시키기
        Vector3 playerDirection = (target.transform.position - firePos.position).normalized;
        Quaternion toRotation = Quaternion.LookRotation(playerDirection, Vector3.up);

        // 회전 각도를 설정
        float rotationAngle = 20f;

        // y축으로 회전시키기 (플레이어 방향을 기준으로 회전)
        Vector3 eulerRotation = new Vector3(0f, toRotation.eulerAngles.y + rotationAngle, 0f);
        testobj.transform.eulerAngles = eulerRotation;
        //if (target != null)
        //{
        //    StartCoroutine(test());
        //}
    }

    public GameObject testobj;
    //IEnumerator test() // 타겟을 쳐다보게
    //{
    //    float time = 0f;

    //    // 회전 애니메이션의 지속 시간
    //    float rotationDuration = 2f;

    //    while (time <= rotationDuration)
    //    {
    //        // 타겟을 바라보게 하는 회전
    //        Vector3 targetDirection = (target.transform.position - firePos.position).normalized;
    //        Quaternion toRotation = Quaternion.LookRotation(targetDirection, Vector3.up);

    //        // 좌우로 25도씩 회전
    //        float rotationAngle = 25f;

    //        // 좌측으로 회전
    //        Quaternion leftRotation = Quaternion.Euler(0f, -rotationAngle, 0f);
    //        Quaternion rotatedLeft = toRotation * leftRotation;

    //        // 우측으로 회전
    //        Quaternion rightRotation = Quaternion.Euler(0f, rotationAngle, 0f);
    //        Quaternion rotatedRight = toRotation * rightRotation;

    //        // 타겟을 바라보게 하는 회전 적용
    //        firePos.transform.rotation = Quaternion.Slerp(rotatedLeft, rotatedRight, time / rotationDuration);

    //        // 타겟을 쳐다보게 하는 회전
    //        testobj.transform.position = firePos.transform.position;
    //        testobj.transform.rotation = firePos.transform.rotation;

    //        yield return null;
    //        time += Time.deltaTime;
    //    }
    //}
}
