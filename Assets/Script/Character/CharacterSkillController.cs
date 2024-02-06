using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;




public enum CharacterSkillState
{
    None,           // 초기 스킨 None으로 셋팅
    Cloaking,       // 은신
    Flying,         // 날기
    psychokinesis   // 염력
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
