using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMove : MonoBehaviour
{
    Vector3 dir;
    public Rigidbody _rigid;
    public float moveSpd;

    void Start()
    {
        
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        dir = new Vector3(h, 0, v);

        /*
        Vector3 dir = transform.forward;
        _rigid.velocity = dir * moveSpd * Time.deltaTime;*/
        
        transform.position += dir * moveSpd * Time.deltaTime;
    }
}
