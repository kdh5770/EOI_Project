using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBGM_End : Interaction
{
    public override void Interact()
    {
        Gamemanager.instance.bgm_manager.OnBossDefeated();
    }
}
