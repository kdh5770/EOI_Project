using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroy : Interaction
{
    [Header ("������ ������Ʈ")]
    public GameObject Destroyobj;

    public override void Interact()
    {
        Destroy(Destroyobj);
    }
}
