using System;
using UnityEngine;

public class GunSoundEvent : MonoBehaviour
{
    CharacterStateController controller;
    //public event Action ActionAttack;
    public AudioSource gunsound;
    public MachineGun machine;
    private void Start()
    {
        controller = transform.root.GetComponent<CharacterStateController>();

    }

    public void gunSoundEvent()
    {
        //ActionAttack?.Invoke();
        if (gunsound != null && gunsound.clip != null)
        {
            gunsound.Play();
            machine.Data.CurBullet--;
        }
/*        gunsound.Play();
        machine.Data.CurBullet--;*/
    }

    public void EndAnimation() // 공격 애니메이션 종료시 호출할 함수
    {
        //controller.ChangeState(CharacterSTATE.MOVE);

    }
}