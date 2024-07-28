using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBGM_Start : Interaction
{
    public override void Interact()
    {
        Gamemanager.instance.bgm_manager.OnEnterBossRoom();
    }
}
