using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public List<Vector3> firstTargets;
    public Transform secondTarget;
    public float waitTime = 3f; // �� ��° ��ǥ�������� ������ �� ��� �ð�

    public GameObject bullet;

    private Rigidbody rb;
    private bool hasReachedFirstTarget = false;

    public List<GameObject> bullets = new List<GameObject>();
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        for(int i =0; i < 10; i++)
        {
            bullets.Add(Instantiate(bullet, transform.position, Quaternion.identity));
        }
        MoveToFirstTarget();
    }

    void Update()
    {
        if (hasReachedFirstTarget)
        {
            // ��� �ð��� ���� �� �� ��° ��ǥ�������� ������
            waitTime -= Time.deltaTime;
            if (waitTime <= 0f)
            {
                foreach (GameObject bullet in bullets)
                {
                    bullet.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
                //MoveToSecondTarget();
            }
        }
    }

    void MoveToFirstTarget()
    {

        for(int i = 0; i < 10; i++)
        {
            Vector3 randomDirection = Random.onUnitSphere;
            Vector3 randomPosition = transform.up * 3 + randomDirection;
            firstTargets.Add(randomPosition);
        }
        // ù ��° ��ǥ�������� �̵�
        for(int i = 0;i < 10;i++)
        {
            Vector3 dir = (firstTargets[i] - transform.position).normalized;
            bullets[i].GetComponent<Rigidbody>().AddForce(dir * 5, ForceMode.Impulse);
        }
    }

    public void MoveToSecondTarget()
    {
        Vector3 directionToSecondTarget = (secondTarget.position - transform.position).normalized;
        rb.AddForce(directionToSecondTarget * 10f, ForceMode.Impulse);
    }
}
