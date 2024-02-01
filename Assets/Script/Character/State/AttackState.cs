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
        controller.playerAnimationEvent.ActionAttack += controller.curWeapon.Using;
        controller.animator.SetTrigger(controller.curWeapon.Data.triggerName);
    }
    public override void OnFixedUpdateState()
    {
        controller.RotateUpdate();
        controller.MoveUpdate();
    }

    public override void OnUpdateState()
    {

    }

    public override void OnExitState()
    {
        controller.playerAnimationEvent.ActionAttack -= controller.curWeapon.Using;
    }

}
