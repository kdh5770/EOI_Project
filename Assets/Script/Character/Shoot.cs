using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    
    public CinemachineVirtualCamera aimCam;
    public bool Aim;
    Animator animator;
    private PlayerInput playerinput;
    private InputAction aimAction;
    [SerializeField]
    private int priorityBoostAmount = 10;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        playerinput = GetComponent<PlayerInput>();
        aimCam=GetComponent<CinemachineVirtualCamera>();
        aimAction = playerinput.actions["Aim"];
    }

    private void OnEnable()
    {
        aimAction.performed += _ => StartAim();
        aimAction.canceled += _ => CancelAim();
    }

    private void OnDisable()
    {
        aimAction.performed -= _ => StartAim();
        aimAction.canceled -= _ => CancelAim();
    }

    private void StartAim()
    {

    }

    private void CancelAim()
    {

    }


    void Aiming()
    {
        if(Input.GetMouseButton(1))
        {
            aimCam.gameObject.SetActive(true);
            Aim = true;
        }
        else
        {
            aimCam.gameObject.SetActive(false);
            Aim = false;
        } 
            
    }

    void OnShoot()
    {
        if((Aim==true)&&Input.GetMouseButton(0))
        {
            animator.SetTrigger("Shoot");
        }
    }
}
