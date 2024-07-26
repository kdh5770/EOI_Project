using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSkill : MonoBehaviour
{
    AudioSource audioSource1;
    public AudioClip audio1;

    void Start()
    {
        audioSource1 = gameObject.AddComponent<AudioSource>();
        StartCoroutine(monsterAudio());
    }

    IEnumerator monsterAudio()
    {
        while (true)
        {
            audioSource1.clip = audio1;
            audioSource1.Play();
            yield return new WaitForSeconds(.7f);
        }
    }
}
