using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharcterInventory : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> InvenObj = new List<GameObject>();

    public void OnInputInven(GameObject _itemname)
    {
        InvenObj.Add(_itemname);
    }
}