using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBox : Interaction
{
    [Header("UI�� ����� ��縦 ��������")]
    public string dialogueText;

    public override void Interact()
    {
        Debug.Log(dialogueText);
    }

}
