using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class MoveState : CharaterBaseState
{
    public override void OnEnterState()
    {
        
    }
    public override void OnUpdateState()
    {
    }
    public override void OnFixedUpdateState()
    {
        CameraRotation();
        Move();
    }

    public override void OnExitState()
    {
        
    }

    private void Move() // �÷��̾� �̵�
    {
        float targetSpeed = controller._input.sprint ? controller.SprintSpeed : controller.MoveSpeed; // input �� �϶� sprintspeed, ������ �� movespeed
        Vector3 inputDirection = new Vector3(controller._input.move.x, 0.0f, controller._input.move.y).normalized;

        if (controller._input.move == Vector2.zero)
        {
            targetSpeed = 0f;
        }

        Vector3 moveDirection = controller._mainCamera.transform.TransformDirection(inputDirection); // ī�޶� �������� input���� �ٲ���
        moveDirection.y = 0f;
        Vector3 moveVector = moveDirection * targetSpeed;
        //_rigidbody.MovePosition(moveVector);

        controller._rigidbody.velocity = new Vector3(moveVector.x, controller._rigidbody.velocity.y, moveVector.z);

        if (moveVector.magnitude > 0f && !controller._input.aim)
        {
            Quaternion newRotation = Quaternion.LookRotation(moveDirection);//, Vector3.up);
            controller.transform.rotation = Quaternion.Slerp(controller.transform.rotation, newRotation, Time.deltaTime * 10f);
        }

        // �ȱ�/�ٱ� �ִϸ��̼� ���
        controller._animator.SetFloat("MoveSpeed", targetSpeed);
    }

    private void CameraRotation() // ī�޶� ȸ��
    {
        // if there is an input and camera position is not fixed
        if (controller._input.look.sqrMagnitude >= controller.Threshold && !controller.LockCameraPosition)
        {
            //Don't multiply mouse input by Time.deltaTime;
            float deltaTimeMultiplier = 1f;

            controller._cinemachineTargetYaw += controller._input.look.x * deltaTimeMultiplier;
            controller._cinemachineTargetPitch += controller._input.look.y * deltaTimeMultiplier;
        }

        // clamp our rotations so our values are limited 360 degrees
        controller._cinemachineTargetYaw = ClampAngle(controller._cinemachineTargetYaw, float.MinValue, float.MaxValue);
        controller._cinemachineTargetPitch = ClampAngle(controller._cinemachineTargetPitch, controller.BottomClamp, controller.TopClamp);

        // Cinemachine will follow this target
        controller.CinemachineCameraTarget.transform.rotation = Quaternion.Euler(controller._cinemachineTargetPitch + controller.CameraAngleOverride, controller._cinemachineTargetYaw, 0.0f);
        if (controller._input.aim)
        {
            controller.transform.rotation = Quaternion.Euler(/*_cinemachineTargetPitch + CameraAngleOverride*/0f, controller._cinemachineTargetYaw, 0.0f);

        }
    }

    private static float ClampAngle(float IfAngle, float IfMin, float IfMax) // ī�޶� ���� ����
    {
        if (IfAngle < -360f) IfAngle += 360f;
        if (IfAngle > 360f) IfAngle -= 360f;
        return Mathf.Clamp(IfAngle, IfMin, IfMax);
    }
}
