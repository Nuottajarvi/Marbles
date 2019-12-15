using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerator : MonoBehaviour
{
    public float force;
    void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        if(rb)
        {
            rb.AddForce(transform.forward * force, ForceMode.Acceleration);
        }
    }
}
