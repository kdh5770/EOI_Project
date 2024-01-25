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

}
