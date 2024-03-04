using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class InputTrigger : MonoBehaviour
{
    [Header("��ȣ�ۿ� ������ �ֱ� - ���� ����")]
    public List<Interaction> interactions;

    public CharacterStateController controller;
    public void InputPlayerTrigger()
    {
        if (interactions.Count > 0)
        {
            Debug.Log("��ǲ Ȯ��");
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
