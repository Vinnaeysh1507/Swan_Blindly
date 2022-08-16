using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour
{
    /*[SerializeField] GameObject playerCam;
    [SerializeField] GameObject NPCCam;
    [SerializeField] GameObject canvas;*/
    Collider collider;
    [SerializeField] GameObject Dialogue;
    [SerializeField] Dialogue dialogue;

    void Start()
    {
        collider = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Dialogue.SetActive(true);
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Dialogue.SetActive(false);
        }
    }
}
