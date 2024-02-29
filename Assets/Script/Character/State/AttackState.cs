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
        Cursor.lockState = CursorLockMode.Locked;
    }

    public override void OnFixedUpdateState()
    {

    }

    public override void OnUpdateState()
    {
        if (!controller.animator.GetCurrentAnimatorStateInfo(1).IsTag("Shoot"))
        {
            controller.ChangeState(CharacterSTATE.MOVE);
        }
        controller.RotateUpdate();
        controller.MoveUpdate();
        controller.ApplyGravity();
    }

    public override void OnExitState()
    {
        
    }
}
