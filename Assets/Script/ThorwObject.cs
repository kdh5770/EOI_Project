using UnityEngine;

public class ThorwObject : MonoBehaviour
{
    public GameObject effectPre;
    public float effectTimer;
    public float damage;

    public void SetDamage(float _damage)
    {
        damage = _damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<CharacterHealth>().TakeDamage(damage);
        }

        Instantiate(effectPre);
        Destroy(effectPre,effectTimer);
        Destroy(gameObject);
    }
}
