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
    public GameObject lowBlood;
    public GameObject middleBlood;
    public GameObject highBlood;

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
            Gamemanager.instance.itemDropManagere.SpawnItems(transform.position);
        }
    }
}
