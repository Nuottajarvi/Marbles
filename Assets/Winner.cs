using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winner : MonoBehaviour
{
    bool over = false;
    void OnCollisionEnter(Collision collision)
    {
        if(!over) { 
            Camera.main.GetComponent<Follow>().forceFollow = collision.gameObject;
            over = true;
        }
    }
}
