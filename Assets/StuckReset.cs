using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuckReset : MonoBehaviour
{

    float stuckTimer = 0;
    float stuckTimerTwo;
    bool secondTimerOn = false;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Magnitude(rb.velocity) < 0.2)
        {
            stuckTimer += Time.deltaTime;

            if (secondTimerOn)
                stuckTimerTwo += Time.deltaTime;
        } else {
            stuckTimer = 0f;
            secondTimerOn = false;
            stuckTimerTwo = 0f;
        }

        if (secondTimerOn && stuckTimerTwo > 1f)
        {
            rb.AddForce(new Vector3(0f, 1000f, 1000f));
            stuckTimerTwo = 0f;
            secondTimerOn = true;
        }

        if (stuckTimer > 1f)
        {
            rb.AddForce(new Vector3(100f, 100f, 0f));
            stuckTimerTwo = 0f;
            secondTimerOn = true;
        }
    }
}