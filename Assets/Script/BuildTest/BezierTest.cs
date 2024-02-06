using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierTest : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public int lineCount;

    public GameObject P0_GameObject;
    public GameObject P1_GameObject;
    public GameObject P2_GameObject;
    public GameObject P3_GameObject;

    public GameObject testItem;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            DraowLineRender();
        }
    }

    void DraowLineRender()
    {
        for (int i = 0; i < lineCount; i++)
        {
            float t;
            if (i == 0)
            {
                t = 0;
            }
            else
            {
                t = (float)i / (lineCount - 1);
            }

            Vector3 bezier = Bezier(P0_GameObject.transform.position, P1_GameObject.transform.position, P2_GameObject.transform.position,
                P3_GameObject.transform.position, t);

            StartCoroutine(TestCou());
            /*
             bezier2 를 써도 됩니다.
            Vector3 bezier2;
            bezier2.x=Bezier(P0_GameObject.transform.position.x, P1_GameObject.transform.position.x, P2_GameObject.transform.position.x,
                P3_GameObject.transform.position.x, t);
            bezier2.y=Bezier(P0_GameObject.transform.position.y, P1_GameObject.transform.position.y, P2_GameObject.transform.position.y,
                P3_GameObject.transform.position.y, t);
            bezier2.z=Bezier(P0_GameObject.transform.position.z, P1_GameObject.transform.position.z, P2_GameObject.transform.position.z,
                P3_GameObject.transform.position.z, t);


            */

            if (lineRenderer != null)
                lineRenderer.SetPosition(i, bezier); // 라인을 설정합니다
        }

    }
    Vector3 Bezier(Vector3 P0, Vector3 P1, Vector3 P2, Vector3 P3, float t)
    {
        Vector3 M0 = Vector3.Lerp(P0, P1, t);
        Vector3 M1 = Vector3.Lerp(P1, P2, t);
        Vector3 M2 = Vector3.Lerp(P2, P3, t);

        Vector3 B0 = Vector3.Lerp(M0, M1, t);
        Vector3 B1 = Vector3.Lerp(M1, M2, t);

        return Vector3.Lerp(B0, B1, t);
    }

    IEnumerator TestCou()
    {
        float time = 0f;
        float t = 0;
        GameObject item = Instantiate(testItem);

        while (t < 1f)
        {
            time += Time.deltaTime;
            t = time / 1f;
            item.transform.position = Bezier(P0_GameObject.transform.position, P1_GameObject.transform.position, P2_GameObject.transform.position,
                P3_GameObject.transform.position, t);
            yield return null;
        }

        Destroy(item);
    }
}
