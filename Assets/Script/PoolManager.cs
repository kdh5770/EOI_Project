using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [Header("총알 오브젝트풀링")]
    public List<GameObject> BulletPool = new List<GameObject>();
    public GameObject BulletPrefab;
    int MaxBull = 20;



    private void Start()
    {
        BulletPooling();
    }


    public void BulletPooling() // 총알풀링 생성
    {
        GameObject BulletPools = new GameObject("BulletPools");

        for (int i = 0; i < MaxBull; i++)
        {
            var obj = Instantiate(BulletPrefab, BulletPools.transform);
            obj.SetActive(false);
            BulletPool.Add(obj);
        }
    }

    public GameObject GetBullet() // 총알풀링 꺼내쓰기
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
