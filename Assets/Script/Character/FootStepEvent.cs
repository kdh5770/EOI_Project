using System;
using System.Collections;
using UnityEngine;

public class FootStepEvent : MonoBehaviour
{
    public AudioSource LeftSound;
    public AudioSource RightSound;
    public GameObject obj;
    CharacterStateController controller;
    private void Start()
    {
        controller = transform.root.GetComponent<CharacterStateController>();
    }

    public void FootSoundEvent(int whichfoot)
    {
        if(whichfoot==0)
        {
            LeftSound.Play();
        }

        else
            RightSound.Play();
    }

    public void EndAnimation() // 공격 애니메이션 종료시 호출할 함수
    {

    }
}