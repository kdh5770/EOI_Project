using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatcherThrow : Attack
{
    [Header("�߻�ü ������")]
    public GameObject BulletEftPre;
    [Header("�߻� ��ġ")]
    public Transform BulletTf;
    [Header("������ �߻�ü")]
    public GameObject BulletEft;
    private const float offest = 0.5f;
    private Vector3 direction;
    public override void ExecuteAttack(GameObject _target)
    {
        animationEvent.ActionAttack += ActionAttack;
        target = _target;
        

        direction = ((target.transform.position + target.transform.up * offest) - transform.root.position).normalized;
        transform.LookAt(target.transform.position);

        //BulletEft = Instantiate(BulletEftPre, BulletTf.transform.position, Quaternion.LookRotation(direction));

        //BulletEft.GetComponent<Rigidbody>().velocity = direction * 30f;
        //BulletEft.transform.LookAt(target.transform.position + target.transform.up * offest);
        
        //BulletEft.GetComponent<Rigidbody>().AddForce(BulletEft.transform.forward * 15f, ForceMode.Impulse);
        //Destroy(BulletEft, 5f);

        animator.SetTrigger("isThrow");
    }

    public override void ActionAttack()
    {
        BulletEft = Instantiate(BulletEftPre, BulletTf.transform.position, Quaternion.LookRotation(direction));
        BulletEft.GetComponent<Rigidbody>().AddForce(BulletEft.transform.forward * 15f, ForceMode.Impulse);
        Destroy(BulletEft, 5f);
        animationEvent.ActionAttack -= ActionAttack;
    }
}
