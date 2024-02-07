using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [Header("캐릭터 총알 풀링")]
    public List<GameObject> BulletPool = new List<GameObject>();
    public GameObject BulletPrefab;



    private void Start()
    {
        BulletPooling();
    }


    public GameObject BulletPooling() // 총알풀링 생성
    {
        var obj = Instantiate(BulletPrefab);
        obj.SetActive(false);
        BulletPool.Add(obj);
        return obj;
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

        return BulletPooling();
    }

}
