using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBox : Interaction
{
    [Header("UI에 출력할 대사를 적으세요")]
    public string dialogueText;

    public override void Interact()
    {
        Debug.Log(dialogueText);
    }

}
