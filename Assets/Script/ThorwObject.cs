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
        if(other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<CharacterHealth>().TakeDamage(damage);
            GameObject eftPre = Instantiate(effectPre, transform.position, Quaternion.identity);
            Destroy(eftPre, effectTimer);
            Destroy(gameObject);
        }
        if(other.gameObject.CompareTag("Wall"))
        {
            GameObject eftPre = Instantiate(effectPre, transform.position, Quaternion.identity);
            Destroy(eftPre, effectTimer);
            Destroy(gameObject);
        }
    }
}
