using System;
using UnityEngine;

public class ReloadingSoundEvent : MonoBehaviour
{
    CharacterStateController controller;
    //public event Action ActionAttack;
    public AudioSource ReloadingSound;
    private void Start()
    {
        controller = transform.root.GetComponent<CharacterStateController>();

    }

    public void reloadSoundEvent()
    {
        //ActionAttack?.Invoke();
        ReloadingSound.Play();
    }

    public void EndAnimation() // 공격 애니메이션 종료시 호출할 함수
    {
        //controller.ChangeState(CharacterSTATE.MOVE);

    }
}