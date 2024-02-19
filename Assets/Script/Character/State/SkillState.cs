using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillState : CharaterBaseState
{
    public SkillState(CharacterStateController _characterStateControllerr)
    {
        controller = _characterStateControllerr;
    }

    public override void OnEnterState()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public override void OnExitState()
    {

    }

    public override void OnFixedUpdateState()
    {
        controller.RotateUpdate();
        controller.MoveUpdate();
    }

    public override void OnUpdateState()
    {

    }
}
