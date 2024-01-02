using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MONSTER_STATE
{
    iDLE = 0,
    TRACKING, // 추적
    MOVE,
    ATTACK, // 근거리 공격
    LONGATTACK, // 원거리 공격
    REACT, // 반응
    HIT, // 피격
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
        Debug.Log("구현 하세용");
    }

    public virtual void ChangeState(MONSTER_STATE _state)
    {
        State = _state;

    }

}
