using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerControl : MonoBehaviour
{
    public GameObject beam;
    public Transform beamTf;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            GameObject beamPre = Instantiate(beam, beamTf.transform.position, Quaternion.identity);
            beamPre.transform.parent = beamTf;
        }
    }
}
