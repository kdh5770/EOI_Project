using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public enum CharcterSkillState
{
    Cloaking,       // 은신
    Flying,         // 날기
    psychokinesis   // 염력
}





public class CharacterSkillController : MonoBehaviour, ISkillStateMachine
{
    [Header("은신관련")]


    [Header("날기")]



    [Header("염력")]
    public float flyingPower = 10f;





    public void OnCloaking(InputAction.CallbackContext _context)
    {

    }

    public void OnFlying(InputAction.CallbackContext _context)
    {

    }


    public void OnPsychokinesis(InputAction.CallbackContext _context)
    {

    }



}
