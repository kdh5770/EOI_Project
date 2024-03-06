using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : CharaterBaseState
{
    public DeathState(CharacterStateController _characterStateControllerr)
    {
        controller = _characterStateControllerr;
    }
    public override void OnEnterState()
    {
        //마우스 고정 해제
        Cursor.lockState = CursorLockMode.None;
        //죽엇을대 UI 팝업

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
