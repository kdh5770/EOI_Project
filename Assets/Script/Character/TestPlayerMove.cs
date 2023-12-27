using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMove : MonoBehaviour
{
    Vector3 dir;
    public float moveSpd;

    void Start()
    {
        
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        dir = new Vector3(v, 0, h);
        transform.position += dir * moveSpd * Time.deltaTime;
    }
}
