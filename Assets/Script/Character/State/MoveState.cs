using UnityEngine;


public class MoveState : CharaterBaseState
{
    public MoveState(CharacterStateController _characterStateControllerr)
    {
        controller = _characterStateControllerr;
    }
    public override void OnEnterState()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    public override void OnUpdateState()
    {
        controller.RotateUpdate();
    }
    public override void OnFixedUpdateState()
    {
        controller.MoveUpdate();

    }

    public override void OnExitState()
    {

    }

}
