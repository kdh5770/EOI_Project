using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Character_Move : MonoBehaviour
{
    private Vector3 moveDirection;
    public float moveSpeed = 4f;
    public Animator animator;
    private Rigidbody rigid;
    Camera camera;
    Vector3 inputvalue;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody>();
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = (transform.right * inputvalue.x + transform.forward * inputvalue.y).normalized;
        rigid.MovePosition(transform.position + (moveDirection * moveSpeed * Time.deltaTime));

    }



    private void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(0, camera.transform.eulerAngles.y, 0);
    }

    void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        if (input != null)
        {

            inputvalue = new Vector3(input.x, 0, input.y);
            animator.SetFloat("X", input.x);
            animator.SetFloat("Y", input.y);
        }
    }
}
