using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionState : CharaterBaseState
{
    public InteractionState(CharacterStateController _characterController)
    {
        controller = _characterController;
    }

    public override void OnEnterState()
    {
        controller.animator.SetTrigger("IsInterAction");
        controller.rigidbody.velocity = Vector3.zero;
        //controller.rigidbody.Sleep();
    }

    public override void OnExitState()
    {
        //controller.rigidbody.WakeUp();

    }

    public override void OnFixedUpdateState()
    {

    }

    public override void OnUpdateState()
    {
    }
}