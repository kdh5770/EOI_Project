using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [Header("Fire �ڽ� ������Ʈ ���� �� �ı�")]
    public int childCount;
    void Update()
    {
        // �θ� ������Ʈ�� �ڽ� ������Ʈ ���� Ȯ��
        childCount = transform.childCount;

        // �θ� ������Ʈ�� �ڽ� ������Ʈ�� ������ �θ� ������Ʈ �ı�
        if (childCount == 0)
        {
            Destroy(gameObject);
            return; // �ı� �Ŀ��� �� �̻� ������ �ʿ� �����Ƿ� return�� ����Ͽ� �޼��� ����
        }
    }
}
