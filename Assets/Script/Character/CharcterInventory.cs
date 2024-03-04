using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharcterInventory : MonoBehaviour
{
    bool isget;

    [SerializeField]
    private List<GameObject> InvenObj = new List<GameObject>();

    public void OnInputInven(GameObject _itemname)
    {
        InvenObj.Add(_itemname);
        Debug.Log("�κ��丮��" + _itemname + "�߰�");
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("InterActionObj"))
        {
            if (Gamemanager.instance.player.GetComponent<CharacterStateController>().curState == Gamemanager.instance.player.GetComponent<CharacterStateController>().states[CharacterSTATE.INTERACTION]&&!isget)
            {
                OnInputInven(other.gameObject);
                isget = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isget = false;
    }
}