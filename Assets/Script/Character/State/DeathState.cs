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
        //���콺 ���� ����
        Cursor.lockState = CursorLockMode.None;
        //�׾����� UI �˾�

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
