using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterEggAttack : MonoBehaviour
{
    public GameObject egg;
    public int encounter = 10;

    public void attackEgg()
    {
        Rigidbody EGG = egg.GetComponent<Rigidbody>();
        EGG.AddForce(transform.forward * encounter, ForceMode.Impulse);
        egg.transform.SetParent(null);
    }
}

