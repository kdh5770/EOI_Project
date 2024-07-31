using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInteraction : Interaction
{
    [Header("출력할 사운드 리소스")]
    public AudioClip clip;

    private AudioSource audioSource;

    private void Awake()
    {
        // AudioSource 컴포넌트를 가져오거나 추가합니다.
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public override void Interact()
    {
        if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
            audioSource.volume = 0.5f;
        }
    }
}