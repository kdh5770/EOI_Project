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
                curEffect.SetActive(false);
                curEffect.transform.position = _hitPoint;
                curEffect.SetActive(true);
            }
            else
            {
                curEffect.transform.position = _hitPoint;
                curEffect.SetActive(true);
            }
            if (!status.GetDie())
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
                curEffect = status.lowBlood;
                break;
            case WEAK_TYPE.MIDDLE:
                reduction = .5f;
                curEffect = status.middleBlood;
                break;
            case WEAK_TYPE.HIGH:
                reduction = 0f;
                curEffect = status.highBlood;
                break;
        }
        if (curEffect != null)
        {
            curEffect.SetActive(false);
        }
    }
}
