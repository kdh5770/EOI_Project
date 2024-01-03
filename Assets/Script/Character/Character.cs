using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Character : MonoBehaviour
{
    public int P_Hp;
    public Vector2 input;
    private Vector3 moveDirection;
    public float moveSpeed = 4f;
    public GameObject AimUI; // ������
    public Animator animator;
    private Rigidbody rigid;
    Camera camera;
    public bool Aiming;


    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody>();
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (P_Hp <= 0)
        {

        }
    }
    private void LateUpdate()
    {
        if (moveDirection != Vector3.zero) // _dir�� 0�� �ƴ϶��, ��! �����̰� �ִٸ�,
        {
            Quaternion quat = Quaternion.LookRotation(moveDirection, Vector3.up); // ù��° ���ڴ� �ٶ󺸴� �����̸�, �ι�° ���ڴ� ���̴�. => ù��° ���ڴ� �ٶ󺸰��� �ϴ� ���⺤�Ͱ� �����Ѵ�.
            transform.rotation = Quaternion.RotateTowards(transform.rotation, quat, 360f * Time.deltaTime); // (ù��°) ���� (�ι�°)���� (����°)�� �ӵ��� ȸ���� ����� �����Ѵ�.
        }

        #region ���� �̵� ����
        //transform.rotation = Quaternion.Euler(0, camera.transform.eulerAngles.y, 0);
        #endregion
    }


    /*    public void OnMove(InputValue value)
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

            #region ���� �̵� ����
            //moveDirection = (transform.right * input.x + transform.forward * input.y).normalized;
            //rigid.MovePosition(transform.position + (moveDirection * moveSpeed * Time.deltaTime));
            #endregion

            moveDirection = (Vector3.right * input.x + Vector3.forward * input.y).normalized; // ������ transform.right�� �ؼ� �÷��̾��� ȸ������ ���� ��� ���ϴµ�, �̸� Vector3.right �� World�������� �̵��ϰ� �������.

            moveDirection = Quaternion.AngleAxis(camera.transform.rotation.eulerAngles.y, Vector3.up) * moveDirection; // ���� _dir * y�� �������� ī�޶��� rotation.y����ŭ Quaternion�� �����Ѵ�.

            moveDirection = moveDirection.normalized; // ����ȭ

            rigid.MovePosition(transform.position + (moveDirection * moveSpeed * Time.deltaTime)); // �̵�

            if (animator.GetBool("Aiming"))
                transform.rotation = Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y, 0f);
        }*/
    public void OnMove(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();


        animator.SetFloat("X", input.x);
        animator.SetFloat("Y", input.y);
        if (input != Vector2.zero)
        {
            animator.SetFloat("Speed", 1);
            return;
        }
        animator.SetFloat("Speed", 0);


        #region ���� �̵� ����
        //moveDirection = (transform.right * input.x + transform.forward * input.y).normalized;
        //rigid.MovePosition(transform.position + (moveDirection * moveSpeed * Time.deltaTime));
        #endregion

        moveDirection = (Vector3.right * input.x + Vector3.forward * input.y).normalized; // ������ transform.right�� �ؼ� �÷��̾��� ȸ������ ���� ��� ���ϴµ�, �̸� Vector3.right �� World�������� �̵��ϰ� �������.

        moveDirection = Quaternion.AngleAxis(camera.transform.rotation.eulerAngles.y, Vector3.up) * moveDirection; // ���� _dir * y�� �������� ī�޶��� rotation.y����ŭ Quaternion�� �����Ѵ�.

        moveDirection = moveDirection.normalized; // ����ȭ

        rigid.MovePosition(transform.position + (moveDirection * moveSpeed * Time.deltaTime)); // �̵�

        if (animator.GetBool("Aiming"))
            transform.rotation = Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y, 0f);
    } // �̵�


    public void OnSit(InputAction.CallbackContext context) // �ɱ�
    {
        if (context.performed)
        {
            animator.SetBool("Sit", true); // �ɱ� �ִϸ��̼� ����
        }
        else if (context.canceled)
            animator.SetBool("Sit", false); // �Ͼ�� �ִϸ��̼� ����
    }


    public void OnAim(InputAction.CallbackContext context) // ����
    {
        if (context.performed)
        {
            Debug.Log("���� ����ϴ�.");
            animator.SetBool("Aiming", true);
            AimUI.SetActive(true);
            Aiming = true;
        }
        else if (context.canceled)
        {
            Debug.Log("���� ����.");
            animator.SetBool("Aiming", false);
            AimUI.SetActive(false);
            Aiming = false;
        }
    }

    public void OnShoot(InputAction.CallbackContext context) // ���
    {
        if (context.performed && Aiming)
        {
            animator.SetBool("Shoot",true);
            Debug.Log("���ϴ�.");
        }
        else if(context.canceled)
        {
            animator.SetBool("Shoot", false);
        }
    }

    public void OnReloading(InputAction.CallbackContext context) // ������
    {
        if (context.performed)
        {
            animator.SetTrigger("Reloading");
            Debug.Log("������ ��.");
        }
    }

    public void OnUseItem(InputAction.CallbackContext context) // ������ ���
    {
        if (context.performed)
        {
            Debug.Log("������ ��� ��.");
        }
    }

    public void OnInterAction(InputAction.CallbackContext context) // ��ȣ�ۿ�
    {
        if (context.performed)
        {
            animator.SetTrigger("InterAction");
            Debug.Log("��ȣ�ۿ� ��.");
        }
    }


    void OnDeath()
    {

    }
}
