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
        //죽엇을대 UI 팝업
        //마우스 고정 해제
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
