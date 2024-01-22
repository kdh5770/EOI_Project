using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraImpulse : Interaction
{
    [Header("Èçµé¸² °­µµ")]
    public float shakeImpulse = 1f;
    public override void Interact()
    {
        CinemachineImpulseSource source = GetComponent<CinemachineImpulseSource>();
        source.GenerateImpulseWithForce(shakeImpulse);
    }
}
