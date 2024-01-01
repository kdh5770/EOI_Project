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
    public GameObject Laser; // ȭ�� ũ�ν���� ������Ʈ
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
            Laser.SetActive(true); // ȭ�鿡 ������ ũ�ν���� ǥ��
            animator.SetBool("Aiming", true);


        }
    }

    void OnAimCanceled(InputAction.CallbackContext context)
    {
        // ���콺 ��Ŭ�� ���� �� ȣ��Ǵ� �޼���
        if (context.canceled)
        {
            Laser.SetActive(false); // ȭ�� ������ ũ�ν���� ����
            animator.SetBool("Aiming", false);
        }
    }
}
