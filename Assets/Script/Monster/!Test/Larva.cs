using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Larva : MonsterStatus
{
    [Header("터지는 이펙트 프리팹")]
    public GameObject boomEftPre;
    [Header("생성된 이펙트")]
    public GameObject boomPreObj;
    [Header("생성된 이펙트 위치")]
    public Transform boom;
    [Header("타겟")]
    public GameObject target;
    [Header("번데기 터질시 나오는 와쳐")]
    public GameObject spawnPre;
    [Header("생성된 와쳐 위치")]
    public Transform spawnPos;
    [Header("발사체 프리팹")]
    public GameObject bullet;
    [Header("발사체 위치")]
    public Transform shotPos;
    [Header("타겟 범위")]
    public int shotTarget = 50;

    float count;
    private Vector3 direction;

    public override void CalculateDamage(float _damage)
    {
        base.CalculateDamage(_damage);
        if (curHP <= 0)
        {
            LarvaBoom();
        }
    }

    public void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, shotTarget);

        if (colliders.Length > 0)
        {
            foreach (Collider col in colliders)
            {
                if (col.CompareTag("Player"))
                {
                    target = col.gameObject;
                    break;
                }
            }
        }
        Vector3 targetPosition = target.transform.position;
        targetPosition.y += 1f;

        Vector3 targetDirection = (targetPosition - shotPos.position).normalized;
        direction = targetDirection;
        count += Time.deltaTime;
        if(count >= 2f)
        {
            GameObject BulletEft = Instantiate(bullet, shotPos.transform.position, Quaternion.LookRotation(direction));
            BulletEft.GetComponent<Rigidbody>().velocity = direction * 30f;
            Destroy(BulletEft, 5f);
            count = 0;
        }
    }
    public void LarvaBoom()
    {
        //gameObject.GetComponent<Collider>().enabled = false;
        boomPreObj = Instantiate(boomEftPre, boom.transform.position, Quaternion.identity);
       
        if (target != null)
        {
            target.GetComponent<CharacterHealth>().TakeDamage(10);
        }
        Destroy(boomPreObj, 2f);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Instantiate(spawnPre, spawnPos.position, Quaternion.identity);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            target = other.gameObject;
            LarvaBoom();
        }
    }
}
