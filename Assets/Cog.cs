using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cog : MonoBehaviour
{
    GameInputManager inputManager;
    public int playerIndex;
    public int spin;
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
        spin = 0;
        if (Input.GetKey(KeyCode.A))
        {
            spin = -1;
        }

        if (Input.GetKey(KeyCode.S/*run*/))
        {
            spin = 1;
        }

        transform.Rotate(new Vector3(0f, spin * -300 * Time.deltaTime, 0f));
    }

    void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        if (rb)
        {
            rb.AddForce(new Vector3(-1f, 0.5f, 0f) * 300 * spin, ForceMode.Acceleration);
        }
    }
}
