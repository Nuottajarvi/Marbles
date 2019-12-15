using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    public KeyCode testingKey_1;
    public KeyCode testingKey_2;
    public GameObject rotatingBlade;
    
    // Start is called before the first frame update
    void Start()
    {
        testingKey_1 = KeyCode.A;
        testingKey_2 = KeyCode.S;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(testingKey_1))
        {
            Debug.Log("Pressing key: " + testingKey_1);  
            rotatingBlade.transform.Rotate(Vector3.forward * 50 * Time.deltaTime);
        } else if (Input.GetKeyDown(testingKey_2))

        {
            Debug.Log("Pressing key: " + testingKey_2);
        }
    }
    
}
