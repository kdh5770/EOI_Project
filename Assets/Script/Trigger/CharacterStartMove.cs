using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStartMove : Interaction
{
    public override void Interact()
    {
        Gamemanager.instance.characterstatecontroller.enabled = true;
    }
}