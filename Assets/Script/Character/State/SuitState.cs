using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitState : CharaterBaseState
{
    public SuitState(CharacterStateController _characterStateControllerr)
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

    }

    public override void OnExitState()
    {

    }
}
