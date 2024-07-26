using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerSound : MonoBehaviour
{
    AudioSource audioSource1;
    AudioSource audioSource2;
    public AudioClip audio1;
    public AudioClip audio2;

    void Start()
    {
        audioSource1 = gameObject.AddComponent<AudioSource>();
        audioSource2 = gameObject.AddComponent<AudioSource>();
        StartCoroutine(monsterAudio());
    }

    IEnumerator monsterAudio()
    {
        while(true)
        {
            audioSource1.clip = audio1;
            audioSource1.Play();
            yield return new WaitForSeconds(3f);
            audioSource2.clip = audio2;
            audioSource2.Play();
            yield return new WaitForSeconds(3f);
        }
    }
}
