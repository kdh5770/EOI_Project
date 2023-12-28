using UnityEngine;
using UnityEngine.InputSystem;

public class Aiming : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private GameObject Laser;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void OnEnable()
    {
        // Input Action을 활성화
        InputAction aimingAction = new InputAction(binding: "<Mouse>/rightButton");
        aimingAction.started += OnAimStarted;
        aimingAction.canceled += OnAimCanceled;
        aimingAction.Enable();
    }

    void OnDisable()
    {
        // Input Action을 비활성화
        InputAction aimingAction = new InputAction(binding: "<Mouse>/rightButton");
        aimingAction.started -= OnAimStarted;
        aimingAction.canceled -= OnAimCanceled;
        aimingAction.Disable();
    }

    void OnAimStarted(InputAction.CallbackContext context)
    {
        // 마우스 우클릭 시작 시 호출되는 메서드
        if (context.started)
        {
            Laser.SetActive(true);
            animator.SetBool("Aiming", true);
        }
    }

    void OnAimCanceled(InputAction.CallbackContext context)
    {
        // 마우스 우클릭 종료 시 호출되는 메서드
        if (context.canceled)
        {
            Laser.SetActive(false);
            animator.SetBool("Aiming", false);
        }
    }
}
