using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveZonePopUp : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            obj.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        obj.SetActive(false);
    }
}
