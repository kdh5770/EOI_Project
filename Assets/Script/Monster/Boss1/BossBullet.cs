using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public GameObject eggEFT;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject obj = Instantiate(eggEFT, transform.position, Quaternion.identity);
            Destroy(obj, 2f);
            Destroy(this.gameObject);
        }
    }
}
