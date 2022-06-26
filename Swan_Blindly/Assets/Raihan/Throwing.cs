using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : MonoBehaviour
{
    [Header("Reference")]
    public Transform cam;
    public Transform throwingPoint;
    public GameObject objectToThrow;

    [Header("Settings")]
    public int totalThrows;
    public float throwCooldown;

    [Header("Throwing")]
    public KeyCode throwkey = KeyCode.Mouse0;
    public float throwForce;
    public float throwUpwardForce;

    bool readyToThrow;

    private LineRenderer line;

    private void Start()
    {
        readyToThrow = true;
        line = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(throwkey) && readyToThrow && totalThrows > 0)
        {           
            Throw ();
            line.enabled = false;
        }
    }

    private void Throw()
    {
        readyToThrow = false;
        line.enabled = true;

        //Instantiate object to throw
        GameObject projectile = Instantiate(objectToThrow, throwingPoint.position, cam.rotation);

        //Get rigidbody component
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        //Calculate direction

        /*Vector3 forceDirection = cam.transform.forward;
        RaycastHit hit;

        if(Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            forceDirection = (hit.point = attackPoint.position).normalized;
        }*/


        //Add force
        Vector3 forceToAdd = cam.transform.forward * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        totalThrows--;

        //ImplementCooldown
        Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }
}
