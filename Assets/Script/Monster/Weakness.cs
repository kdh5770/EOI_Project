using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weakness : MonoBehaviour
{
    public enum WEAK_TYPE
    {
        None,
        LOW,
        MEDIUM,
        HIGH,
    }

    public WEAK_TYPE type;

    public MonsterStatus status;
    private float reduction;

    private void Start()
    {
        if (type != WEAK_TYPE.None)
            this.gameObject.tag = "Monster";

        GameObject root = transform.root.gameObject;
        status = root.GetComponent<MonsterStatus>();
        InitType();
    }
    public void AttackDamage(float _damage)
    {
        float result = _damage - (_damage * reduction);

        status.CalculateDamage(result);
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
                break;
            case WEAK_TYPE.MEDIUM:
                reduction = .5f;
                break;
            case WEAK_TYPE.HIGH:
                reduction = 0f;
                break;
        }
    }
}
