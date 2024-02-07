using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [Header("�Ѿ� ������ƮǮ��")]
    public List<GameObject> BulletPool = new List<GameObject>();
    public GameObject BulletPrefab;
    int MaxBull = 20;



    private void Start()
    {
        BulletPooling();
    }


    public void BulletPooling() // �Ѿ�Ǯ�� ����
    {
        GameObject BulletPools = new GameObject("BulletPools");

        for (int i = 0; i < MaxBull; i++)
        {
            var obj = Instantiate(BulletPrefab, BulletPools.transform);
            obj.SetActive(false);
            BulletPool.Add(obj);
        }
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
        return null;
    }

}
