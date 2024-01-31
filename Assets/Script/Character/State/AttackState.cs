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
        time = 3f;
        controller.curWeapon.Using();
    }
    float time = 1;
    public override void OnFixedUpdateState()
    {
        controller.RotateUpdate();
        controller.MoveUpdate();
    }

    public override void OnUpdateState()
    {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            controller.ChangeState(CharacterSTATE.MOVE);
        }
    }

    public override void OnExitState()
    {
    }

}
