using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public enum CharcterSkillState
{
    Cloaking,       // ����
    Flying,         // ����
    psychokinesis   // ����
}





public class CharacterSkillController : MonoBehaviour, ISkillStateMachine
{
    [Header("���Ű���")]


    [Header("����")]



    [Header("����")]
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
