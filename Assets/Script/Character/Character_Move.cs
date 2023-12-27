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

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody>();
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = (transform.right * input.x + transform.forward * input.y).normalized;
        rigid.MovePosition(transform.position + (moveDirection * moveSpeed * Time.deltaTime));
    }



    private void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(0, camera.transform.eulerAngles.y, 0);
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
