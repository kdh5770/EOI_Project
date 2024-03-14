using Unity.VisualScripting;
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
        
    }
    public override void OnFixedUpdateState()
    {
        controller.RotateUpdate();
        controller.MoveUpdate();
        controller.FlyingUpdate();
        controller.ApplyGravity();
    }

    public override void OnExitState()
    {

    }

}
