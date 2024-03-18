using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroy : Interaction
{
    [Header ("제거할 오브젝트")]
    public GameObject Destroyobj;

    public override void Interact()
    {
        Destroy(Destroyobj);
    }
}
