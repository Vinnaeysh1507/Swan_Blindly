using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCCatBehaviour : MonoBehaviour
{
    Collider collider;
    public bool hasItem;
    public GameObject Dialogue;

    void Start()
    {
        collider = GetComponent<Collider>();
        //hasItem = GetComponent<Inventory>().items;
        Dialogue.SetActive(false);
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Dialogue.SetActive(true);
            
            if(hasItem = true)
            {
                Debug.Log("Yes");
            }

            if(hasItem = false)
            {
                Debug.Log("No");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Dialogue.SetActive(false);
        }
    }
}
