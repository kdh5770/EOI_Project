using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    [Header("UI에 출력할 대사를 적으세요")]
    public string dialogueText;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("UI 대사 출력");
        }
    }
}
