using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : MonoBehaviour
{
    GameInputManager inputManager;
    public int playerIndex;
    public float maxMovement;
    float movement;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameInputManager = GameObject.Find("GameInputManager");
        if (gameInputManager != null)
            inputManager = gameInputManager.GetComponent<GameInputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        /*Player player = inputManager.listOfPlayers[playerIndex];
        KeyCode left = player.playerKey_1;
        KeyCode right = player.playerKey_2;
        */

        if (Input.GetKey(KeyCode.A) && movement > -maxMovement)
        {
            transform.position -= Time.deltaTime * transform.right;
            movement -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S/*run*/) && movement < maxMovement)
        {
            transform.position += Time.deltaTime * transform.right;
            movement += Time.deltaTime;
        }
    }
}
