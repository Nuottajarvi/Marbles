using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{

    GameInputManager inputManager;
    Rigidbody rb;
    public int playerIndex;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameInputManager = GameObject.Find("GameInputManager");
        if(gameInputManager != null)
            inputManager = gameInputManager.GetComponent<GameInputManager>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*Player player = inputManager.listOfPlayers[playerIndex];
        KeyCode turn = player.playerKey_1;
        KeyCode run = player.playerKey_2;
        */

        if(Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(Vector3.up);
        }

        if (Input.GetKey(KeyCode.S/*run*/))
        {
            rb.AddForce(transform.forward * 10);
        }
    }
}
