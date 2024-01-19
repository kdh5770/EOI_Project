using System.Collections;
using UnityEngine;

public class AutoPickup : MonoBehaviour
{
    public float follwSpeed;

    public Vector3 P0_GameObject;
    public Vector3 P1_GameObject;
    public Vector3 P2_GameObject;
    public Vector3 P3_GameObject;

    private void Start()
    {
        P0_GameObject = gameObject.transform.position;
        P1_GameObject = gameObject.transform.up * 5f;
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            StartCoroutine(PathFollowing());
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

    IEnumerator PathFollowing()
    {
        float time = 0f;
        float t = 0;

        while (t < 1f)
        {
            time += Time.deltaTime;
            t = time / follwSpeed;
            transform.position = Bezier(P0_GameObject, P1_GameObject, P2_GameObject,
                P3_GameObject, t);
            yield return null;
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            P2_GameObject = other.transform.position + other.transform.forward * -1;
            P3_GameObject = other.transform.position + other.transform.up * 1.5f;
            StartCoroutine(PathFollowing());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            P2_GameObject = other.transform.position + other.transform.forward * -1;
            P3_GameObject = other.transform.position + other.transform.up * 1.5f;
        }
    }
    
}
