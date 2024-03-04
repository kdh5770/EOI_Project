using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill_Damage : MonoBehaviour
{
    public float damage;

    public void SetDamage(float _damage)
    {
        damage = _damage;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<CharacterHealth>().TakeDamage(damage);
        }
    }
}
