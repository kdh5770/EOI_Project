using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burstEgg : MonoBehaviour
{
    public GameObject boomPre;
    public GameObject boomPre_;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            boomPre_ = Instantiate(boomPre, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(boomPre_, 4f);
        }
    }
}
