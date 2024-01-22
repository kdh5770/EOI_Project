using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraImpulse : Interaction
{
    public override void Interact()
    {
        CinemachineImpulseSource source = GetComponent<CinemachineImpulseSource>();
        source.GenerateImpulse();
    }
}
