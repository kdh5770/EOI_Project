using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill_KCC : MonoBehaviour
{
    public Transform trs;
    public GameObject eft;

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("�ε���?: " + other.name);
        Instantiate(eft, transform.position, Quaternion.identity);
    }
}
