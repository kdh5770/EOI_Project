using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerEggAttack : MonoBehaviour
{
    public GameObject eggPre;
    public Transform firePos;
    public int encounter = 20;

    public void attackEgg()
    {
        GameObject preObj = Instantiate(eggPre, firePos.position, Quaternion.identity);

        preObj.GetComponent<Rigidbody>().AddForce(transform.forward * encounter, ForceMode.Impulse);
    }
}
