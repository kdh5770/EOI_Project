using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("â Ȱ��ȭ")]
    public GameObject inventory;
    [Header("�κ��丮 â")]
    public GameObject inventory_;
    [Header("�� â")]
    public GameObject Map_;
    [Header("����Ʈ â")]
    public GameObject Quest_;

    private void Start()
    {
        inventory.SetActive(false);
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.Tab))
        {
            Time.timeScale = 0;
            inventory.SetActive(true);
        }
    }

    public void Onclick_Inventory()
    {
        inventory_.SetActive(true);
        Map_.SetActive(false);
        Quest_.SetActive(false);
    }

    public void Onclick_Map()
    {
        inventory_.SetActive(false);
        Map_.SetActive(true);
        Quest_.SetActive(false);
    }

    public void Onclick_Quest()
    {
        inventory_.SetActive(false);
        Map_.SetActive(false);
        Quest_.SetActive(true);
    }

    public void Onclick_Exit()
    {
        inventory.SetActive(false);
    }
}
