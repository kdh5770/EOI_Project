using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMsgPoPup : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Gamemanager.instance.characterUI.ControlTowerTxt(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Gamemanager.instance.characterUI.ControlTowerTxt(false);
    }
}
