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
    public float asd;

    public override void Interact()
    {
        //Time.timeScale = 0f; // Ÿ�Ӷ��� ���� ���� ��� ������ �Ͻ� ����
        Gamemanager.instance.timeLineManager.SetInteraction(pd, timeLine);
        while(true)
        {
            asd += Time.deltaTime;
        }
        //pd.stopped += OnTimelineStopped; // Ÿ�Ӷ����� ���� �� �簳�ǵ��� ����
    }

    private void OnTimelineStopped(PlayableDirector director) // Ÿ�Ӷ����� ���� �� ȣ��Ǵ� �޼���
    {
        Time.timeScale = 1f; // �Ͻ� ������ �����ϰ� ������ �ð����� ����
        pd.stopped -= OnTimelineStopped; // �̺�Ʈ �����ʸ� ����
    }
}
