using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDontMove : Interaction
{
    public override void Interact()
    {
        Gamemanager.instance.characterstatecontroller.enabled = false;
    }
}