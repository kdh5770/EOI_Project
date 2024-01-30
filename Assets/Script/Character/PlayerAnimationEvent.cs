using System;
using UnityEngine;

public class PlayerAnimationEvent : MonoBehaviour
{
    CharacterController controller;
    public event Action ActionAttack;
    private void Start()
    {
        controller = transform.root.GetComponent<CharacterController>();
    }

    public void EventAnimation()
    {
        ActionAttack?.Invoke();
    }

    public void EndAnimation() // 공격 애니메이션 종료시 호출할 함수
    {
        
    }
}
