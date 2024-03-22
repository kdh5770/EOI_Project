using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class WorkerTimeLine : Interaction
{
    [Header("Ÿ�Ӷ��� ������ �߰� �ϼ���")]
    public TimelineAsset timeLine;
    public PlayableDirector pd;
    [Header("Ÿ�Ӷ��ο� ���� ������Ʈ �ı�")]
    public List<GameObject> gameobjects;
    [Header("�÷��̾� ��ġ �̵�")]
    public GameObject player;
    public Transform playerPos;

    public Transform worker;
    public override void Interact()
    {
        Time.timeScale = 0;
        Gamemanager.instance.player.GetComponent<CharacterStateController>().enabled = false;
        Gamemanager.instance.player.GetComponent<CharacterStateController>().rigidbody.velocity = Vector3.zero;
        Gamemanager.instance.timeLineManager.SetInteraction(pd, timeLine);
        pd.stopped += OnTimelineStopped; // Ÿ�Ӷ����� ���� �� �簳�ǵ��� ����
    }

    private void OnTimelineStopped(PlayableDirector director) // Ÿ�Ӷ����� ���� �� ȣ��Ǵ� �޼���
    {
        foreach (GameObject interaction in gameobjects)
        {
            Destroy(interaction.gameObject);
        }
        Time.timeScale = 1;

        Collider[] colliders_ = Physics.OverlapSphere(transform.position, 100f);
        if (colliders_.Length > 0)
        {
            foreach (Collider cols in colliders_)
            {
                if (cols.CompareTag("Destroy"))
                {
                    worker = cols.gameObject.transform;
                    break;
                }
            }
        }

        Debug.Log("Ÿ�ӽ����� 1");
        player.transform.position = playerPos.position;
        Gamemanager.instance.player.GetComponent<CharacterStateController>().enabled = true;
        pd.stopped -= OnTimelineStopped; // �̺�Ʈ �����ʸ� ����
    }
}