using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class CutSceneInteraction : Interaction
{
    [Header("Ÿ�Ӷ��� ������ �߰� �ϼ���")]
    public TimelineAsset timeLine;
    public PlayableDirector pd;
    [Header("Ÿ�Ӷ��� ���� �� Ȱ��ȭ�Ǵ� Ʈ����")]
    public GameObject bossCollider;
    [Header("Ÿ�Ӷ��ο� ���� ������Ʈ �ı�")]
    public List<GameObject> gameobjects;

    public override void Interact()
    {
        Gamemanager.instance.timeLineManager.SetInteraction(pd, timeLine);
        pd.stopped += OnTimelineStopped; // Ÿ�Ӷ����� ���� �� �簳�ǵ��� ����
    }

    private void OnTimelineStopped(PlayableDirector director) // Ÿ�Ӷ����� ���� �� ȣ��Ǵ� �޼���
    {
        foreach (GameObject interaction in gameobjects)
        {
            Destroy(interaction.gameObject);
        }
        bossCollider.SetActive(true);
        pd.stopped -= OnTimelineStopped; // �̺�Ʈ �����ʸ� ����
    }
}
