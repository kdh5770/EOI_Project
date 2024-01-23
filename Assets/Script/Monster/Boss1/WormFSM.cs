
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class WormFSM : MonsterFSM
{
    public GameObject target;

    public float attackTime = 0; // 공격 딜레이


    public float rotationSpeed = 2f;

    public WormHealth wormHealth;
    public BossSkillController skillController;

    bool isSpecialSkill;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        wormHealth = GetComponent<WormHealth>();
        skillController = GetComponentInChildren<BossSkillController>();

        ChangeState(MONSTER_STATE.iDLE);
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
        animator.SetBool("isIdle", true);
        animator.SetBool("IsLongAttack", false);
        animator.SetBool("IsSpout", false);
        animator.SetBool("IsSpout2", false);
        animator.SetBool("IsWall", false);
    }

    void UpdateIdle()
    {

    }

    void SetTracking()
    {
        animator.SetBool("isIdle", true);
    }
    void UpdateTracking() // 추적 타겟 감지
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, wormHealth.sightRange);

        if (colliders.Length > 0)
        {
            foreach (Collider col in colliders)
            {
                if (col.CompareTag("Player"))
                {
                    target = col.gameObject;
                    ChangeState(MONSTER_STATE.ATTACK);
                    break;
                }
            }
        }
    }

    void SetAttack()
    {
        animator.SetBool("isIdle", true);
        skillController.SetAttackState(target);
    }

    void UpdateAttack()
    {

    }

    float time = 0f;
    void UpdateDie()
    {
        time += Time.deltaTime;
        if (time >= 3)
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


    public override void ChangeReactionState(REACT_TYPE _state)
    {
        throw new System.NotImplementedException();
    }
}


