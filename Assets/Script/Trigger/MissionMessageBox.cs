using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionMessageBox : Interaction
{
    [Header("UI에 출력할 대사를 적으세요")]
    [TextArea(3, 10)]
    public string dialogueText;

    public override void Interact()
    {
        Gamemanager.instance.characterUI.SetMissiontxt(dialogueText);
    }
}