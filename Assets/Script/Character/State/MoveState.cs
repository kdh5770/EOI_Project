using UnityEngine;


public class MoveState : CharaterBaseState
{
    public MoveState(CharacterStateController _characterStateControllerr)
    {
        controller = _characterStateControllerr;
    }
    public override void OnEnterState()
    {

    }
    public override void OnUpdateState()
    {
    }
    public override void OnFixedUpdateState()
    {
        if (controller.isAiming)
            controller.transform.rotation = Quaternion.Euler(0f, controller.cinemachineTargetYaw, 0.0f);
        controller.CinemachineCameraTarget.transform.rotation = Quaternion.Euler(controller.cinemachineTargetPitch, controller.cinemachineTargetYaw, 0.0f);

        if (controller.inputDir != Vector3.zero)
        {
            controller.applySpeed = controller.isSprint ? controller.sprintSpeed : controller.moveSpeed;
            controller.animator.SetFloat("MoveSpeed", controller.applySpeed);

            Vector3 moveVector = controller.mainCamera.transform.TransformDirection(controller.inputDir); // 카메라 기준으로 input값을 바꿔줌
            moveVector.y = 0f;
            moveVector *= controller.applySpeed;
            controller.rigidbody.velocity = new Vector3(moveVector.x, controller.rigidbody.velocity.y, moveVector.z);

            if (moveVector.magnitude > 0f && !controller.isAiming)
            {
                Quaternion newRotation = Quaternion.LookRotation(moveVector);//, Vector3.up);
                controller.transform.rotation = Quaternion.Slerp(controller.transform.rotation, newRotation, Time.deltaTime * 10f);
            }
        }
        else
        {
            controller.animator.SetFloat("MoveSpeed", 0);
            controller.rigidbody.velocity = Vector3.zero;
        }
    }

    public override void OnExitState()
    {

    }

}
