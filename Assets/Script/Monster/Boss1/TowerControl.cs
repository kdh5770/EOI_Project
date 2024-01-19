using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerControl : MonoBehaviour
{
    public GameObject egg;
    public Image g;

    public Transform tower;
    public int dist;

    private void Start()
    {
        g.gameObject.SetActive(false);
    }
    private void Update()
    {
        if(egg != null)
        {
            g.gameObject.SetActive(true);
            if(Input.GetKey(KeyCode.G))
            {
                egg.transform.parent = tower;
            }
        }
        else
        {
            g.gameObject.SetActive(false);
        }
    }
}
