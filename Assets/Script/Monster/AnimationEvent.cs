using System;
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
