using System;
using UnityEngine;

public class PlayerAnimationEvent : MonoBehaviour
{
    CharacterStateController controller;
    public event Action ActionAttack;
    private void Start()
    {
        controller = transform.root.GetComponent<CharacterStateController>();
    }

    public void EventAnimation()
    {
        ActionAttack?.Invoke();
    }

    public void EndAnimation() // 공격 애니메이션 종료시 호출할 함수
    {
        Debug.Log("endAni");
        controller.ChangeState(CharacterSTATE.MOVE);
    }
}
