using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInteraction : Interaction
{
    [Header("����� ���� ���ҽ�")]
    public AudioClip clip;
    public override void Interact()
    {
        Debug.Log(clip.name);
    }
}
