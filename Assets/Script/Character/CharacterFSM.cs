using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum STATE
{
    NONE = 0,
    Idle,
    Moving,
    UsingMelee,
    UsingGun,
    Reaction,
    CutScene,
    Dead
}

public class CharacterFSM : MonoBehaviour, IStateMachine
{
    public void ChangeReactionState(REACT_TYPE _state)
    {
        Debug.Log("구현하세요");
    }
}
