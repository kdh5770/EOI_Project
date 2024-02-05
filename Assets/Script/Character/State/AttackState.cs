using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : CharaterBaseState
{
    public AttackState(CharacterStateController _characterStateControllerr)
    {
        controller = _characterStateControllerr;
    }

    public override void OnEnterState()
    {

    }
    public override void OnFixedUpdateState()
    {
        controller.RotateUpdate();
        controller.MoveUpdate();
    }

    public override void OnUpdateState()
    {
        if (!controller.animator.GetCurrentAnimatorStateInfo(1).IsTag("Shoot"))
        {
            controller.ChangeState(CharacterSTATE.MOVE);
        }

    }

    public override void OnExitState()
    {

    }

}
