using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [Header("ĳ���� �Ѿ� Ǯ��")]
    public List<GameObject> BulletPool = new List<GameObject>();
    public GameObject BulletPrefab;



    private void Start()
    {
        BulletPooling();
    }


    public GameObject BulletPooling() // �Ѿ�Ǯ�� ����
    {
        var obj = Instantiate(BulletPrefab);
        obj.SetActive(false);
        BulletPool.Add(obj);
        return obj;
    }

    public GameObject GetBullet() // �Ѿ�Ǯ�� ��������
    {
        for (int i = 0; i < BulletPool.Count; i++)
        {
            if (BulletPool[i].activeSelf == false)
            {
                return BulletPool[i];
            }
        }

        return BulletPooling();
    }

}
