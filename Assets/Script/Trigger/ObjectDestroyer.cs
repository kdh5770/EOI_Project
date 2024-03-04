using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : Interaction
{
    [Header("작동 off 오브젝트")]
    [SerializeField]
    private GameObject gameobj1;

    [Header("작동 on 오브젝트")]
    [SerializeField]
    private GameObject gameobj2;


    public override void Interact()
    {
        gameobj1.SetActive(false);
        gameobj2.SetActive(true);
    }
}