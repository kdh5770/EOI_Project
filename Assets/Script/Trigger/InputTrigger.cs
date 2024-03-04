using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class InputTrigger : MonoBehaviour
{
    [Header("상호작용 프리팹 넣기 - 복수 가능")]
    public List<Interaction> interactions;

    public CharacterStateController controller;
    public void InputPlayerTrigger()
    {
        if (interactions.Count > 0)
        {
            Debug.Log("인풋 확인");
            foreach (Interaction interaction in interactions)
            {
                interaction.Interact();
            }
            controller.inputTrigger = null;
            this.GetComponent<Collider>().enabled = false;
            Gamemanager.instance.characterUI.OnInputTrigger(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Gamemanager.instance.characterUI.OnInputTrigger(true);
            controller = other.GetComponent<CharacterStateController>();
            controller.inputTrigger = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Gamemanager.instance.characterUI.OnInputTrigger(false);
            controller = other.GetComponent<CharacterStateController>();
            controller.inputTrigger = null;
        }
    }
}
