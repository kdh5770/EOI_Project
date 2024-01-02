using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MONSTER_STATE
{
    iDLE = 0,
    TRACKING, // ����
    MOVE,
    ATTACK, // �ٰŸ� ����
    LONGATTACK, // ���Ÿ� ����
    REACT, // ����
    HIT, // �ǰ�
    CUTSCENE, // 
    DIE
}

public class MonsterFSM : MonoBehaviour, IStateMachine
{

    public MONSTER_STATE State;

    protected Animator animator;

    protected MonsterStatus monsterStatus;

    public void ChangeReactionState(REACT_TYPE _state)
    {
        Debug.Log("���� �ϼ���");
    }

    public virtual void ChangeState(MONSTER_STATE _state)
    {
        State = _state;

    }

}
