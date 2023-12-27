using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
public class Character_Move : MonoBehaviour
{
    private Vector3 moveDirection;
    private float moveSpeed = 4f;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool hasControl = (moveDirection != Vector3.zero);
        if(hasControl)
        {
            transform.rotation=Quaternion.LookRotation(moveDirection);
            transform.Translate(Vector3.forward*Time.deltaTime*moveSpeed);
        }
    }

    void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        if(input != null)
        {
            moveDirection = new Vector3(input.x, 0f, input.y);
            animator.SetFloat("moveSpeed", input.magnitude);
        }
    }
}
