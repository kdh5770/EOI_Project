using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;




public enum CharacterSkillState
{
    None,           // �ʱ� ��Ų None���� ����
    Cloaking,       // ����
    Flying,         // ����
    psychokinesis   // ����
}




public class CharacterSkillController : MonoBehaviour
{




    void Start()
    {




        InitSkillState();

    }


    public void ChangeSkillState(REACT_TYPE _state)
    {
        throw new System.NotImplementedException();
    }



    void InitSkillState()
    {

    }

}
