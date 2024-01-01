using UnityEngine;
using UnityEngine.InputSystem;

public class AimAndShot : MonoBehaviour
{
    public enum AimState
    {
        NotAiming, Aiming
    }

    public AimState aimstate {  get; private set; }

    private Animator animator;
    public GameObject Laser; // 화면 크로스헤어 오브젝트
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
            Laser.SetActive(true); // 화면에 빨강색 크로스헤어 표시
            animator.SetBool("Aiming", true);


        }
    }

    void OnAimCanceled(InputAction.CallbackContext context)
    {
        // 마우스 우클릭 종료 시 호출되는 메서드
        if (context.canceled)
        {
            Laser.SetActive(false); // 화면 빨강색 크로스헤어 없앰
            animator.SetBool("Aiming", false);
        }
    }
}
