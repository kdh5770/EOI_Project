using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWallTF : MonoBehaviour
{
    public Transform boom;
    public GameObject wallPrefab; // Wall �������� ������ ����

    public float count = 0; // ���� �ð�
    public int count_ = 0; // 1���� �����ϱ� ���� ī��Ʈ

    private void Update()
    {
        count += Time.deltaTime;

        if (count >= 30f && count_ == 0) // ������ ���� ���� ��������
        {
            // Wall �������� �ν��Ͻ�ȭ
            GameObject wallInstance = Instantiate(wallPrefab, boom.transform.position, Quaternion.identity);

            // ������ Wall�� boom�� �ڽ����� ����
            wallInstance.transform.parent = boom;

            count_ = 1;
        }
    }
}
