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
        inputManager = GameObject.Find("GameInputManager").GetComponent<GameInputManager>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Player player = inputManager.listOfPlayers[playerIndex];
        KeyCode turn = player.playerKey_1;
        KeyCode run = player.playerKey_2;

        Debug.Log(run);

        if (Input.GetKey(run))
        {
            Debug.Log("ADDING FORCE");
            rb.AddForce(transform.forward * 100);
        }
    }
}
