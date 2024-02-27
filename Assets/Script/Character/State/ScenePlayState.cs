using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePlayState : CharaterBaseState
{
    public ScenePlayState(CharacterStateController _characterStateControllerr)
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
