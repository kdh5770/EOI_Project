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

    //public Transform worker;
    public override void Interact()
    {
        Time.timeScale = 0;
        Gamemanager.instance.timeLineManager.SetInteraction(pd, timeLine);
        pd.stopped += OnTimelineStopped; // Ÿ�Ӷ����� ���� �� �簳�ǵ��� ����
    }

    private void OnTimelineStopped(PlayableDirector director) // Ÿ�Ӷ����� ���� �� ȣ��Ǵ� �޼���
    {
        foreach (GameObject interaction in gameobjects)
        {
            Destroy(interaction.gameObject);
        }

        player.transform.position = playerPos.position;
        player.transform.rotation = playerPos.rotation;

        Time.timeScale = 1;

        pd.stopped -= OnTimelineStopped; // �̺�Ʈ �����ʸ� ����
    }
}