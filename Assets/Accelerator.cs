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
            rb.AddForce(transform.forward * force * Random.Range(0.8f, 1.2f), ForceMode.Acceleration);
        }
    }
}
