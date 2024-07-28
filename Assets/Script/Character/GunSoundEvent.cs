using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GunSoundEvent : MonoBehaviour
{
    CharacterStateController controller;
    public AudioSource gunsound;
    public MachineGun machine;
    [SerializeField]
    private AudioClip[] GunClip;

    private int currentClipIndex = 0;
    private bool isFiring = false;
    private float fireRate = 0.1f; // 사운드 재생 간격 (초 단위)
    private float nextFireTime = 0f;

    private void Start()
    {

    }

    // 애니메이션 이벤트에 연결할 메서드
    public void OnShoot()
    {
        if (Time.time >= nextFireTime)
        {
            PlayGunSound();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void PlayGunSound()
    {
        if (currentClipIndex < 0 || currentClipIndex >= GunClip.Length)
        {
            Debug.LogError("유효하지 않은 인덱스입니다. currentClipIndex를 0으로 설정합니다.");
            currentClipIndex = 0;
        }

        AudioClip clip = GunClip[currentClipIndex];
        if (clip != null)
        {
            gunsound.clip = clip;
            gunsound.Play();
            Debug.Log("사운드 재생: " + currentClipIndex);
        }
        else
        {
            Debug.LogWarning("GunClip 배열의 " + currentClipIndex + "번째 요소가 비어 있습니다.");
        }

        // 인덱스 증가 및 범위 검사
        currentClipIndex++;
        if (currentClipIndex >= GunClip.Length)
        {
            currentClipIndex = 0;
        }

        machine.Data.CurBullet--;
    }

    public void EndAnimation()
    {
        // controller.ChangeState(CharacterSTATE.MOVE); // 필요할 때 주석 해제
    }
}
