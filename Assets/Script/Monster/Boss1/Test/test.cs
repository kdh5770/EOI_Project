using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public List<Vector3> firstTargets;
    public Transform secondTarget;
    public float waitTime; // �� ��° ��ǥ�������� ������ �� ��� �ð�

    public GameObject bullet;

    private Rigidbody rb;
    private bool hasReachedFirstTarget = false;

    public List<GameObject> bullets = new List<GameObject>();
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        waitTime = 3f;
        hasReachedFirstTarget = true;

        for (int i = 0; i < 10; i++)
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
                hasReachedFirstTarget = false;
                foreach (GameObject bullet in bullets)
                {
                    bullet.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
                StartCoroutine(MoveToSecondTarget());
            }
        }
    }

    void MoveToFirstTarget()
    {

        for (int i = 0; i < 10; i++)
        {
            Vector3 randomDirection = Random.onUnitSphere;
            Vector3 randomPosition = transform.up * 3 + randomDirection;
            firstTargets.Add(randomPosition);
        }
        // ù ��° ��ǥ�������� �̵�
        for (int i = 0; i < 10; i++)
        {
            Vector3 dir = firstTargets[i].normalized;
            bullets[i].GetComponent<Rigidbody>().AddForce(dir * 5, ForceMode.Impulse);
        }
    }

    IEnumerator MoveToSecondTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 25f);

        if (colliders.Length > 0)
        {
            foreach (Collider col in colliders)
            {
                if (col.CompareTag("Player"))
                {
                    secondTarget = col.gameObject.transform;
                    break;
                }
            }
        }

        foreach(GameObject bullet in bullets)
        {
            Vector3 directionToSecondTarget = (secondTarget.position - bullet.transform.position).normalized;
            bullet.GetComponent<Rigidbody>().AddForce(directionToSecondTarget * 20, ForceMode.Impulse);
            yield return new WaitForSeconds(.5f);
        }
    }
}
