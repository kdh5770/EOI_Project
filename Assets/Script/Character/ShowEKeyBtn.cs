using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowEKeyBtn : MonoBehaviour
{
    [SerializeField]
    private GameObject EBtn;



    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(Blink());
        }
    }

    private void OnTriggerExit(Collider other)
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
