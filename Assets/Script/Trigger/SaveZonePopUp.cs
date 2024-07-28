using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveZonePopUp : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    [SerializeField]
    AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Play();
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            obj.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        obj.SetActive(false);
    }
}
