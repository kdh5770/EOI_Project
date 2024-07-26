using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_Manager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] audioClips; // BGM 클립 배열
    private AudioSource audioSource; // BGM 재생을 위한 오디오 소스

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // 게임 시작 시 첫 번째 BGM 재생
        PlayBGM(0);
    }

    public void PlayBGM(int index)
    {
        if (index >= 0 && index < audioClips.Length)
        {
            audioSource.clip = audioClips[index];
            audioSource.Play();
        }
    }

    // 보스방에 들어갔을 때 호출
    public void OnEnterBossRoom()
    {
        PlayBGM(1);
    }

    // 보스가 죽었을 때 호출
    public void OnBossDefeated()
    {
        PlayBGM(2);
    }
}
