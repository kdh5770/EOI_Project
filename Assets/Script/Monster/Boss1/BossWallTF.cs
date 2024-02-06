using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWallTF : MonoBehaviour
{
    public Transform boom;
    public GameObject wallPrefab; // Wall 프리팹을 변수로 변경

    public float count = 0; // 생성 시간
    public int count_ = 0; // 1개만 생성하기 위한 카운트

    private void Update()
    {
        count += Time.deltaTime;

        if (count >= 30f && count_ == 0) // 터지는 장판 언제 생성할지
        {
            // Wall 프리팹을 인스턴스화
            GameObject wallInstance = Instantiate(wallPrefab, boom.transform.position, Quaternion.identity);

            // 생성된 Wall을 boom의 자식으로 설정
            wallInstance.transform.parent = boom;

            count_ = 1;
        }
    }
}
