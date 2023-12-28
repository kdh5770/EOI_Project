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
        // Input Action�� Ȱ��ȭ
        InputAction aimingAction = new InputAction(binding: "<Mouse>/rightButton");
        aimingAction.started += OnAimStarted;
        aimingAction.canceled += OnAimCanceled;
        aimingAction.Enable();
    }

    void OnDisable()
    {
        // Input Action�� ��Ȱ��ȭ
        InputAction aimingAction = new InputAction(binding: "<Mouse>/rightButton");
        aimingAction.started -= OnAimStarted;
        aimingAction.canceled -= OnAimCanceled;
        aimingAction.Disable();
    }

    void OnAimStarted(InputAction.CallbackContext context)
    {
        // ���콺 ��Ŭ�� ���� �� ȣ��Ǵ� �޼���
        if (context.started)
        {
            Laser.SetActive(true);
            animator.SetBool("Aiming", true);
        }
    }

    void OnAimCanceled(InputAction.CallbackContext context)
    {
        // ���콺 ��Ŭ�� ���� �� ȣ��Ǵ� �޼���
        if (context.canceled)
        {
            Laser.SetActive(false);
            animator.SetBool("Aiming", false);
        }
    }
}
