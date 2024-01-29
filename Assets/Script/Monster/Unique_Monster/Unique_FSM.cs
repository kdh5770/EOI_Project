using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unique_FSM : MonsterFSM
{
    private Unique_SkillController skillController;

    private void Start()
    {
        skillController = GetComponentInChildren<Unique_SkillController>();
    }

    public override void ChangeReactionState(REACT_TYPE _state)
    {
        throw new System.NotImplementedException();
    }
}
