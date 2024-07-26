using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSkill : MonoBehaviour
{
    AudioSource audioSource1;
    public AudioClip audio1;

    float count = 0;

    void Start()
    {
        audioSource1 = gameObject.AddComponent<AudioSource>();
    }

    public void Update()
    {
        count += Time.deltaTime;

        if(count >= 0.7f)
        {
            audioSource1.clip = audio1;
            audioSource1.Play();

            count = 0f;
        }
    }
}
