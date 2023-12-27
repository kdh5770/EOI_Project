using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public CinemachineVirtualCamera aimCam;
    public bool Aim;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Aiming();
        OnShoot();
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
