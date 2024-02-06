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

    public void EndAnimation() // 공격 애니메이션 종료시 호출할 함수
    {
        monsterFSM.ChangeState(MONSTER_STATE.TRACKING);
    }
}
