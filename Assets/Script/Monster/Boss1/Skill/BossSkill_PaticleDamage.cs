using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill_PaticleDamage : MonoBehaviour
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

    private void OnParticleCollision(GameObject other)
    {
        CharacterHealth player = other.GetComponent<CharacterHealth>();
        if(player != null && damageCount >= .1f)
        {
            player.TakeDamage(damage);
            damageCount = 0;
        }
    }
}
