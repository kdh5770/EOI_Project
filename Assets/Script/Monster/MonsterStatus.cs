using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MonsterFSM;

public class MonsterStatus : MonoBehaviour
{   
    public int maxHP;
    public int curHP;
    public int ATK;
    public int DEF;

    public float bassSPD;
    public float moveRange;
    public float sightRange;

    public GameObject dropItemPre;

    protected MonsterFSM monsterFSM;

    public virtual void CalculateDamage(int _damage, int _weakenValue)
    {
        curHP -= _damage - (DEF - _weakenValue);
        if(curHP <= 0)
        {
            monsterFSM.ChangeState(MONSTER_STATE.DIE);
        }
    }
}
