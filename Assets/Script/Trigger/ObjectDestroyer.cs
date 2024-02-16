using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : ObjectSpawner
{
    void DestroyObject()
    {
        if (checkKill)
        {
            Destroy(this.gameObject);
        }
    }
}
