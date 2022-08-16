using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMeshEndPoint : MonoBehaviour
{
    [SerializeField] private float radius = 3f;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject jumpButton;
    [SerializeField] private GameObject fishSpawner;
    //[SerializeField] private SphereCollider endPointCollider;

    private void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= radius)
        {
            jumpButton.SetActive(true);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void OnTriggerEnter(Collider other)
    {
        fishSpawner.SetActive(false);
    }
}