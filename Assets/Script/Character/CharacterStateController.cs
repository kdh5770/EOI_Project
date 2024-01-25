using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterStateController : MonoBehaviour, IStateMachine
{
    public PlayerInput input;
    public ICharaterBaseState curState;

    MoveState moveState;
    private void Start()
    {
        moveState = new MoveState();
    }

    private void Update()
    {
        curState.OnUpdateState();
    }

    private void FixedUpdate()
    {
        curState.OnFixedUpdateState();
    }

    public void ChangeState(ICharaterBaseState _state)
    {
        curState.OnExitState();
        curState = _state;
        curState.OnEnterState();
    }

    public void ChangeReactionState(REACT_TYPE _state)
    {
        throw new System.NotImplementedException();
    }
}
