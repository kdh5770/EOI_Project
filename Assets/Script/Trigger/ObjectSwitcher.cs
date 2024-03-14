using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSwitcher : Interaction
{
    [Header("�۵� off ������Ʈ")]
    [SerializeField]
    private GameObject gameobj1;

    [Header("�۵� on ������Ʈ")]
    [SerializeField]
    private GameObject gameobj2;


    public override void Interact()
    {
        gameobj2.SetActive(true);
        gameobj1.SetActive(false);
    }
}