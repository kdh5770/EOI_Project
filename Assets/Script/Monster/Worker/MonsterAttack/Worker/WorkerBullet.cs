using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            Debug.Log("Çה");
        }
        else
        {
            Destroy(this.gameObject, 3f);
        }
    }
}
