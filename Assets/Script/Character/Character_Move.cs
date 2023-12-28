using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Character_Move : MonoBehaviour
{
    public Vector2 input;
    private Vector3 moveDirection;
    public float moveSpeed = 4f;

    public Animator animator;
    private Rigidbody rigid;
    Camera camera;



    float _magnitude;
    public float _x;
    public float _y;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody>();
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //moveDirection = (transform.right * input.x + transform.forward * input.y).normalized;
        //rigid.MovePosition(transform.position + (moveDirection * moveSpeed * Time.deltaTime));

        _x = input.x;
        _y = input.y;

        moveDirection = (transform.right * _x + transform.forward * _y).normalized;

        moveDirection = Quaternion.AngleAxis(camera.transform.rotation.eulerAngles.y, Vector3.up) * moveDirection; // ���� _dir * y�� �������� ī�޶��� rotation.y����ŭ Quaternion�� �����Ѵ�.

        moveDirection = moveDirection.normalized;

        _magnitude = Mathf.Clamp01(moveDirection.magnitude) * moveSpeed;
    }



    private void LateUpdate()
    {
        if (moveDirection != Vector3.zero) // _dir�� 0�� �ƴ϶��, ��! �����̰� �ִٸ�,
        {
            Quaternion quat = Quaternion.LookRotation(moveDirection, Vector3.up); // ù��° ���ڴ� �ٶ󺸴� �����̸�, �ι�° ���ڴ� ���̴�. => ù��° ���ڴ� �ٶ󺸰��� �ϴ� ���⺤�Ͱ� �����Ѵ�.
            transform.rotation = Quaternion.RotateTowards(transform.rotation, quat, 720f * Time.deltaTime); // (ù��°) ���� (�ι�°)���� (����°)�� �ӵ��� ȸ���� ����� �����Ѵ�.
        }

        //transform.rotation = Quaternion.Euler(0, camera.transform.eulerAngles.y, 0);
    }

    void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();

        animator.SetFloat("X", input.x);
        animator.SetFloat("Y", input.y);
        if (input != Vector2.zero)
        {
            animator.SetFloat("Speed", 1);
            return;
        }
        animator.SetFloat("Speed", 0);
    }
}
