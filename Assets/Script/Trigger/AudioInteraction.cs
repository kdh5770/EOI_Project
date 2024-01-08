using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInteraction : Interaction
{
    [Header("출력할 사운드 리소스")]
    public AudioClip clip;
    public override void Interact()
    {
        Debug.Log(clip.name);
    }
}
