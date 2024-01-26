using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [Header("Fire 자식 오브젝트 없을 시 파괴")]
    public int childCount;
    void Update()
    {
        // 부모 오브젝트의 자식 오브젝트 갯수 확인
        childCount = transform.childCount;

        // 부모 오브젝트의 자식 오브젝트가 없으면 부모 오브젝트 파괴
        if (childCount == 0)
        {
            Destroy(gameObject);
            return; // 파괴 후에는 더 이상 진행할 필요 없으므로 return을 사용하여 메서드 종료
        }
    }
}
