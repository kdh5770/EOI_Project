using System.Collections;
using System.Collections.Generic;

public class InteractionState : CharaterBaseState
{
    public InteractionState(CharacterStateController _characterController)
    {
        controller = _characterController;
    }

    public override void OnEnterState()
    {
        controller.animator.SetTrigger("IsInterAction");
    }

    public override void OnExitState()
    {

    }

    public override void OnFixedUpdateState()
    {

    }

    public override void OnUpdateState()
    {

    }
}