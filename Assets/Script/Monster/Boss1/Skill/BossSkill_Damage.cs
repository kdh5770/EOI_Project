using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill_Damage : MonoBehaviour
{
    public float damage;
    float damageCount;

    public void Update()
    {
        damageCount += Time.deltaTime;
    }
    public void SetDamage(float _damage)
    {
        damage = _damage;
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(damageCount >= .5f)
            {
                other.GetComponent<CharacterHealth>().TakeDamage(damage);
                damageCount = 0;
            }
        }
    }
}
