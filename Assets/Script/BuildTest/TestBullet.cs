using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBullet : MonoBehaviour
{
    public List<GameObject> PreObj;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            int i = Random.Range(0, PreObj.Count);
            Instantiate(PreObj[i], transform.position, Quaternion.identity);
        }
    }
}
