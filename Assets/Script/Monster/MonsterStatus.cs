using System;
using UnityEngine;

public class MonsterData
{
    public float HP;
    public float ATK;
    public float DEF;
    public float speed;
    public float sightRange;
    public float dropItemCount;
    public Vector3 scale;

    public MonsterData(float _HP, float _aTK, float _dEF, float _speed, float _sightRange, float _dropItemCount, Vector3 _scale)
    {
        this.HP = _HP;
        ATK = _aTK;
        DEF = _dEF;
        this.speed = _speed;
        this.sightRange = _sightRange;
        this.dropItemCount = _dropItemCount;
        this.scale = _scale;
    }
}

public class MonsterStatus : MonoBehaviour
{
    public float maxHP;
    public float curHP;
    public float ATK;
    public float DEF;

    public float bassSPD;
    public float moveRange;
    public float sightRange;
    public float attackRange;

    public GameObject lowBlood;
    public GameObject middleBlood;
    public GameObject highBlood;

    protected MonsterFSM monsterFSM;
    public MonsterData monsterData;

    private bool dieCheck;

    private void Start()
    {
        if (TryGetComponent(out MonsterFSM _monsterFSM))
        {
            monsterFSM = _monsterFSM;
        }
    }

    public virtual void CalculateDamage(float _damage)
    {
        curHP -= _damage;

        if (curHP <= 0)
        {
            monsterFSM?.ChangeState(MONSTER_STATE.DIE);
            Gamemanager.instance.itemDropManagere.SpawnItems(transform.position);
            
            if(dieCheck)
            {
                Gamemanager.instance.spawnManager.AddKillCount();
            }
        }
    }

    public bool GetDie()
    {
        return curHP <= 0;
    }

    public void SpawnInit(MonsterData _data, bool _isCounting)
    {
        monsterData = _data;

        maxHP = monsterData.HP;
        curHP = maxHP;
        ATK = monsterData.ATK;
        DEF = monsterData.DEF;
        bassSPD = monsterData.speed;
        sightRange = monsterData.sightRange;

        Animator animator = GetComponentInChildren<Animator>();
        animator.transform.localScale = monsterData.scale;

        dieCheck = _isCounting;
    }

}
