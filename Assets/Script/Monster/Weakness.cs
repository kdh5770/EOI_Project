using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weakness : MonoBehaviour
{
    public enum WEAK_TYPE
    {
        None,
        LOW,
        MIDDLE,
        HIGH,
    }

    public WEAK_TYPE type;

    public MonsterStatus status;
    private float reduction;

    private GameObject curEffect;

    private void Start()
    {
        if (type != WEAK_TYPE.None)
            this.gameObject.tag = "Monster";

        GameObject root = transform.root.gameObject;
        status = root.GetComponent<MonsterStatus>();
        InitType();
    }
    public void AttackDamage(float _damage, Vector3 _hitPoint)
    {
        if (type != WEAK_TYPE.None)
        {
            float result = _damage - (_damage * reduction);

            if (curEffect.activeSelf)
            {
                curEffect.transform.position = _hitPoint;
                curEffect.SetActive(false);
                curEffect.SetActive(true);
            }
            else
            {
                curEffect.transform.position = _hitPoint;
                curEffect.SetActive(true);
            }
            status.CalculateDamage(result);
        }
    }

    void InitType()
    {
        switch (type)
        {
            case WEAK_TYPE.None:
                reduction = 1f;
                break;
            case WEAK_TYPE.LOW:
                reduction = .3f;
                curEffect = Instantiate(status.lowBlood, transform.position, Quaternion.identity);
                break;
            case WEAK_TYPE.MIDDLE:
                reduction = .5f;
                curEffect = Instantiate(status.middleBlood, transform.position, Quaternion.identity);
                break;
            case WEAK_TYPE.HIGH:
                reduction = 0f;
                curEffect = Instantiate(status.highBlood, transform.position, Quaternion.identity);
                break;
        }
    }
}
