using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    GameInputManager inputManager;
    public int playerIndex;
    bool launching = false;
    float launchingTimer = 0f;
    float cooldown = 0f;

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
        KeyCode bounce = player.playerKey_1;
        KeyCode right = player.playerKey_2;
        */

        if(launching)
        {
            launchingTimer += Time.deltaTime;
            if (launchingTimer < 0.1f)
                transform.position += Vector3.up * Time.deltaTime * 50f;
            else if (launchingTimer < 0.3f)
                transform.position += Vector3.down * Time.deltaTime * .5f * 50f;
            else
            {
                launchingTimer = 0f;
                launching = false;
            }
        }

        if (Input.GetKey(KeyCode.A) && cooldown < 0f)
        {
            launching = true;
            cooldown = 2;
        }

        cooldown -= Time.deltaTime;
    }
}
