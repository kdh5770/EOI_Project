using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowEKeyBtn : MonoBehaviour
{
    [SerializeField]
    private GameObject EBtn;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CutScene")
        {
            StartCoroutine(Blink());
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        EBtn.SetActive(false);
        StopAllCoroutines();
    }

    IEnumerator Blink()
    {
        while(true)
        {
            EBtn.SetActive(!EBtn.activeSelf);
            yield return new WaitForSeconds(.5f);
        }
    }
}
