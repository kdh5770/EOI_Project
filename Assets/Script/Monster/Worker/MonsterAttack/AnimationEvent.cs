using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    MonsterFSM monsterFSM;

    private void Start()
    {
        monsterFSM = transform.root.GetComponent<MonsterFSM>();
    }

    public void EndAnimation()
    {
        monsterFSM.ChangeState(MONSTER_STATE.TRACKING);
    }
}
