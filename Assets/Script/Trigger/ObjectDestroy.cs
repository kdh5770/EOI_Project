using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectDestroy : Interaction
{
    [Header ("제거할 오브젝트")]
    public GameObject Destroyobj;

    public override void Interact()
    {
        StartCoroutine(waitTimeCo());
    }


    IEnumerator waitTimeCo()
    {
        yield return new WaitForSeconds(4f);
        Destroy(Destroyobj);
    }
}
