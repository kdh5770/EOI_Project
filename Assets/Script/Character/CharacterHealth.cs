using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHP;
    public int curHP;
    public int maxCost;
    public int curCost;

    public float ATK;
    public float DEF;
    public float baseSpeed;

    public void TakeDamage(float _damage)
    {
        curHP -= ((int)(_damage - DEF));

        if (curHP <= 0)
        {
            Debug.Log("�÷��̾� ���");
        }
    }
}
