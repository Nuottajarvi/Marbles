using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    Color color;
    bool on = true;
    // Start is called before the first frame update
    
    public void SetColor(Color color)
    {
        this.color = color;
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.SetColor("_EmissionColor", color);
    }

    public void TurnOn()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.SetColor("_EmissionColor", color);
        on = true;
    }

    public void TurnOff()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.SetColor("_EmissionColor", Color.black);
        on = false;
    }

    public void Switch()
    {
        if (on)
            TurnOff();
        else
            TurnOn();
    }
}
