using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBullet : MonoBehaviour
{
    private Rigidbody rigid;
    public float damage;
    public bool isCollision;
    [SerializeField]
    private GameObject BloodObj;

    Transform camTransform;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        camTransform = Camera.main.transform;
    }

    public void SetBulle(float _damage)
    {
        damage = _damage;
    }

    private void Update()
    {
        BullSetFalse();
    }

    private void OnDisable()
    {
        rigid.velocity = Vector3.zero;
        rigid.Sleep();
    }

    void BullSetFalse()
    {
        RaycastHit hit;
        isCollision = Physics.Raycast(transform.position, transform.forward, out hit, 5,LayerMask.GetMask("Ground", "Monster"));
        if (isCollision)
        {
            if (hit.collider.TryGetComponent(out Weakness weakness))
            {
                hit.collider.GetComponent<Weakness>().AttackDamage(damage, hit.transform.position);
                GameObject eftObj = Instantiate(BloodObj, hit.point, Quaternion.identity);
                eftObj.transform.LookAt(camTransform.transform.position);
                Destroy(eftObj, 1f);
            }
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
