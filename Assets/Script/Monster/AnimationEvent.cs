using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    MonsterFSM monsterFSM;
    public event Action ActionAttack;
    private void Start()
    {
        monsterFSM = transform.root.GetComponent<MonsterFSM>();
    }

    public void EventAnimation()
    {
        ActionAttack?.Invoke();
    }

    public void EndAnimation() // ���� �ִϸ��̼� ����� ȣ���� �Լ�
    {
        monsterFSM.ChangeState(MONSTER_STATE.TRACKING);
    }
}
