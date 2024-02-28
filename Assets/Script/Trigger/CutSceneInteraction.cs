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
    [Header("Ÿ�Ӷ��ο� ���� ������Ʈ �ı�")]
    public List<GameObject> gameobjects;

    public bool isinteraction;

    public float boss;

    public override void Interact()
    {
        //Time.timeScale = 0;
        Gamemanager.instance.timeLineManager.SetInteraction(pd, timeLine);
        isinteraction = true;
        pd.stopped += OnTimelineStopped; // Ÿ�Ӷ����� ���� �� �簳�ǵ��� ����
    }

    private void OnTimelineStopped(PlayableDirector director) // Ÿ�Ӷ����� ���� �� ȣ��Ǵ� �޼���
    {
        foreach (GameObject interaction in gameobjects)
        {
            Destroy(interaction.gameObject);
        }
        //Time.timeScale = 1;
        isinteraction = false;
        pd.stopped -= OnTimelineStopped; // �̺�Ʈ �����ʸ� ����
    }
}