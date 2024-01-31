using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestWorker : MonoBehaviour
{
    public Transform location1;
    public Transform location2;
    public GameObject worker;

    private NavMeshAgent agent;
    private bool isFirstMoveComplete = false;

    public void Start()
    {
        agent = worker.GetComponent<NavMeshAgent>();
        MoveToLocation(location1.position);
        StartCoroutine(Up());
    }

    void MoveToLocation(Vector3 targetPosition)
    {
        agent.SetDestination(targetPosition);
        isFirstMoveComplete = true;
    }

    IEnumerator Up()
    {
        // 첫 번째 이동이 완료되면 두 번째 이동 시작
        if (isFirstMoveComplete && !agent.pathPending && agent.remainingDistance < 0.1f)
        {
            MoveToLocation(location2.position);
            isFirstMoveComplete = false;
        }
        yield return null;
    }
}
