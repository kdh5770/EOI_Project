using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("창 활성화")]
    public GameObject inventory;
    [Header("인벤토리 창")]
    public GameObject inventory_;
    [Header("맵 창")]
    public GameObject Map_;
    [Header("퀘스트 창")]
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
