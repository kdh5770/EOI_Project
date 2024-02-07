using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBullet : MonoBehaviour
{
    public float damage;

    public void SetBulle(float _damage)
    {
        damage = _damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Weakness weakness))
        {
            other.GetComponent<Weakness>().AttackDamage(damage, other.transform.position);
        }
        Debug.Log(other.gameObject.name);
        this.gameObject.SetActive(false);
    }
}
