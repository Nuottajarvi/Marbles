using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateUnits : MonoBehaviour
{
    public GameObject[] units;
    public bool activate;
    // Start is called before the first frame update
    void OnTriggerEnter()
    {
        foreach(GameObject unit in units)
        {
            unit.SetActive(activate);
        }
    }
}
