using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject poolPre;
    public List<GameObject> pools;

    public GameObject GetFromPool()
    {
        // Look for an inactive object in the pool
        foreach (GameObject obj in pools)
        {
            if (!obj.activeSelf)
            {
                obj.SetActive(true); // Reactivate the object
                return obj;
            }
        }

        // Optionally expand the pool if no inactive object is found
        GameObject newObj = Instantiate(poolPre);
        newObj.SetActive(true);
        pools.Add(newObj);
        newObj.transform.SetParent(transform); // Optional
        return newObj;
    }
}
