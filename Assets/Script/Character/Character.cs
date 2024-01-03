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
    public GameObject AimUI; // 조준점
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
        if (moveDirection != Vector3.zero) // _dir이 0이 아니라면, 즉! 움직이고 있다면,
        {
            Quaternion quat = Quaternion.LookRotation(moveDirection, Vector3.up); // 첫번째 인자는 바라보는 방향이며, 두번째 인자는 축이다. => 첫번째 인자는 바라보고자 하는 방향벡터가 들어가야한다.
            transform.rotation = Quaternion.RotateTowards(transform.rotation, quat, 360f * Time.deltaTime); // (첫번째) 에서 (두번째)까지 (세번째)의 속도로 회전한 결과를 리턴한다.
        }

        #region 기존 이동 로직
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

            #region 기존 이동 로직
            //moveDirection = (transform.right * input.x + transform.forward * input.y).normalized;
            //rigid.MovePosition(transform.position + (moveDirection * moveSpeed * Time.deltaTime));
            #endregion

            moveDirection = (Vector3.right * input.x + Vector3.forward * input.y).normalized; // 기존엔 transform.right로 해서 플레이어의 회전값에 따라 계속 변하는데, 이를 Vector3.right 즉 World기준으로 이동하게 만들었다.

            moveDirection = Quaternion.AngleAxis(camera.transform.rotation.eulerAngles.y, Vector3.up) * moveDirection; // 기존 _dir * y축 기준으로 카메라의 rotation.y값만큼 Quaternion을 리턴한다.

            moveDirection = moveDirection.normalized; // 정규화

            rigid.MovePosition(transform.position + (moveDirection * moveSpeed * Time.deltaTime)); // 이동

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


        #region 기존 이동 로직
        //moveDirection = (transform.right * input.x + transform.forward * input.y).normalized;
        //rigid.MovePosition(transform.position + (moveDirection * moveSpeed * Time.deltaTime));
        #endregion

        moveDirection = (Vector3.right * input.x + Vector3.forward * input.y).normalized; // 기존엔 transform.right로 해서 플레이어의 회전값에 따라 계속 변하는데, 이를 Vector3.right 즉 World기준으로 이동하게 만들었다.

        moveDirection = Quaternion.AngleAxis(camera.transform.rotation.eulerAngles.y, Vector3.up) * moveDirection; // 기존 _dir * y축 기준으로 카메라의 rotation.y값만큼 Quaternion을 리턴한다.

        moveDirection = moveDirection.normalized; // 정규화

        rigid.MovePosition(transform.position + (moveDirection * moveSpeed * Time.deltaTime)); // 이동

        if (animator.GetBool("Aiming"))
            transform.rotation = Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y, 0f);
    } // 이동


    public void OnSit(InputAction.CallbackContext context) // 앉기
    {
        if (context.performed)
        {
            animator.SetBool("Sit", true); // 앉기 애니메이션 실행
        }
        else if (context.canceled)
            animator.SetBool("Sit", false); // 일어서기 애니메이션 실행
    }


    public void OnAim(InputAction.CallbackContext context) // 조준
    {
        if (context.performed)
        {
            Debug.Log("조준 땡깁니다.");
            animator.SetBool("Aiming", true);
            AimUI.SetActive(true);
            Aiming = true;
        }
        else if (context.canceled)
        {
            Debug.Log("조준 해제.");
            animator.SetBool("Aiming", false);
            AimUI.SetActive(false);
            Aiming = false;
        }
    }

    public void OnShoot(InputAction.CallbackContext context) // 사격
    {
        if (context.performed && Aiming)
        {
            animator.SetBool("Shoot",true);
            Debug.Log("쏩니다.");
        }
        else if(context.canceled)
        {
            animator.SetBool("Shoot", false);
        }
    }

    public void OnReloading(InputAction.CallbackContext context) // 재장전
    {
        if (context.performed)
        {
            animator.SetTrigger("Reloading");
            Debug.Log("재장전 중.");
        }
    }

    public void OnUseItem(InputAction.CallbackContext context) // 아이템 사용
    {
        if (context.performed)
        {
            Debug.Log("아이템 사용 중.");
        }
    }

    public void OnInterAction(InputAction.CallbackContext context) // 상호작용
    {
        if (context.performed)
        {
            animator.SetTrigger("InterAction");
            Debug.Log("상호작용 중.");
        }
    }


    void OnDeath()
    {

    }
}
