using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    bool isget;

    [SerializeField]
    public List<GameObject> InvenObj = new List<GameObject>();

    public void OnInputInven(GameObject _itemname)
    {
        InvenObj.Add(_itemname);
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("InterActionObj"))
        {
            if (Gamemanager.instance.player.GetComponent<CharacterStateController>().curState == Gamemanager.instance.player.GetComponent<CharacterStateController>().states[CharacterSTATE.INTERACTION]&&!isget)
            {
                OnInputInven(other.gameObject);
                other.gameObject.SetActive(false);
                isget = true;
            }
        }

        if (other.CompareTag("InterActionObj2"))
        {
            if (Gamemanager.instance.player.GetComponent<CharacterStateController>().curState == Gamemanager.instance.player.GetComponent<CharacterStateController>().states[CharacterSTATE.INTERACTION] && !isget)
            {
                OnInputInven(other.gameObject);
                other.gameObject.SetActive(false);
                isget = true;
            }
        }

        if (other.CompareTag("InterActionObj3"))
        {
            if (Gamemanager.instance.player.GetComponent<CharacterStateController>().curState == Gamemanager.instance.player.GetComponent<CharacterStateController>().states[CharacterSTATE.INTERACTION] && !isget)
            {
                OnInputInven(other.gameObject);
                other.gameObject.SetActive(false);
                isget = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isget = false;
    }
}