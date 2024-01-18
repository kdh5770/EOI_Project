using UnityEngine;

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

    public GameObject dropItemPre;

    protected MonsterFSM monsterFSM;

    private void Start()
    {
        monsterFSM = GetComponent<MonsterFSM>();
    }

    public virtual void CalculateDamage(float _damage)
    {
        curHP -= _damage;
        if(curHP <= 0)
        {
            monsterFSM.ChangeState(MONSTER_STATE.DIE);
        }
    }
}
