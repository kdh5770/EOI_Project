using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weakness : MonoBehaviour
{
    public MonsterStatus status;
    public int test;
    private void Start()
    {
        this.gameObject.tag = "Monster";
        GameObject root = transform.root.gameObject;
        status = root.GetComponent<MonsterStatus>();
    }
    public void AttackDamage(int _damage)
    {
        status.CalculateDamage(_damage, test);
    }
}
