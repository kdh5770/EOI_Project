using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Larva : MonoBehaviour
{
    public GameObject boomEft;
    public GameObject boomEft_;
    public Transform boom;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            boomEft_ = Instantiate(boomEft, boom.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(boomEft_, 2f);
        }
    }
}
