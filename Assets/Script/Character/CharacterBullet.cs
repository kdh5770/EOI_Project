using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBullet : MonoBehaviour
{
    public float damage;
    public bool isCollision;

    public void SetBulle(float _damage)
    {
        damage = _damage;
    }

    private void Update()
    {
        BullSetFalse();
    }

    void BullSetFalse()
    {
        RaycastHit hit;
        isCollision = Physics.Raycast(transform.position, transform.forward, out hit, 5,LayerMask.GetMask("Ground", "Monster"));
        if (isCollision)
        {
            this.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Weakness weakness))
        {
            other.GetComponent<Weakness>().AttackDamage(damage, other.transform.position);
        }
    }
}
