using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingReset : MonoBehaviour
{
    List<Vector3> lastPositions;
    bool reversing = false;
    bool flash = false;
    Lamp lamp;
    float flashTimer = 0.25f;

    public float returnTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        lastPositions = new List<Vector3>();
        lamp = GetComponent<Lamp>();
    }

    // Update is called once per frame
    void Update()
    {
        if(reversing)
        {
            if (lastPositions.Count == 0) {
                reversing = false;
                lamp.TurnOn();
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                return;
            }

            if(flashTimer < 0)
            {
                lamp.Switch();
                flashTimer += 0.25f;
            }

            flashTimer -= Time.deltaTime;

            Vector3 pos = lastPositions[lastPositions.Count - 1];
            lastPositions.RemoveAt(lastPositions.Count - 1);

            transform.position = pos;
        }
        else
        {
            float fps = 1 / Time.deltaTime;
            if(lastPositions.Count > returnTime * fps)
            {
                lastPositions.RemoveAt(0);
            }
            lastPositions.Add(transform.position);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("outofbounds"))
            reversing = true;
    }
}
