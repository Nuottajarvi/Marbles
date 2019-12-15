using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [HideInInspector]
    public GameObject[] players;
    public float smoothing;
    Vector3 followPosition = new Vector3(-7f, 7f, 7f);

    public GameObject forceFollow;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject leadingPlayer = players[0];

        foreach(GameObject player in players)
        {
            if(player.transform.position.y < leadingPlayer.transform.position.y)
            {
                leadingPlayer = player;
            }
        }

        if (forceFollow)
            leadingPlayer = forceFollow;

        transform.position = Vector3.Lerp(
            transform.position,
            leadingPlayer.transform.position + followPosition,
            smoothing * Time.deltaTime
        );
    }
}
