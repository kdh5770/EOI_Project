using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWallTF : MonoBehaviour
{
    public Transform boom;
    public GameObject wall;

    public float count = 0;

    private void Update()
    {
        count += Time.deltaTime;

        if(count >= 3f)
        {
            Instantiate(wall, boom.transform.position, Quaternion.identity);
        }
    }
}
