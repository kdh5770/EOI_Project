using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class CharacterMove : MonoBehaviour
{
    public CharacterInputSystem input;
    Rigidbody rigid;
    Animator animator;
    Camera camera;
    public CinemachineVirtualCamera nomalCam;
    public CinemachineVirtualCamera aimCam;


    public float sprintSpeed;
    public float moveSpeed;
    public float targetSpeed;

    public GameObject cameraTarget;
    public float rotateTopClamp;
    public float rotateBottomClamp;
    public float mouseX;
    public float mouseY;
    public float turnSmoothVelocity;
    public float turnSmoothTime;

    private void Start()
    {
        input = GetComponent<CharacterInputSystem>();
        rigid = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        camera = Camera.main;
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (input.move == Vector2.zero)
        {
            targetSpeed = 0;
            animator.SetFloat("Speed", targetSpeed);
            return;
        }

        targetSpeed = input.sprint ? sprintSpeed : moveSpeed; // input 참 일때 sprintspeed, 거짓일 때 movespeed

        Vector3 direction = new Vector3(input.move.x, 0, input.move.y).normalized;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.transform.eulerAngles.y;
        // Smoothly rotate the character towards the target angle
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        // Move the character
        Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

        rigid.MovePosition(transform.position + moveDirection.normalized * targetSpeed * Time.fixedDeltaTime);
        // 걷기/뛰기 애니메이션 출력
        animator.SetFloat("Speed", targetSpeed);
    }

    private void LateUpdate()
    {
        if(input.aim)
        {
            transform.LookAt(camera.transform.forward);
            return;
        }

        mouseX += input.look.x;
        mouseY -= input.look.y;

        cameraTarget.transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);
    }
}
