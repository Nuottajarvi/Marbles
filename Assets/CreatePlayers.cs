using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayers : MonoBehaviour
{
    public GameObject player;
    public int playerCount;

    public Color[] colors;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < playerCount; ++i)
        {

            Vector3 randomPosition = new Vector3();
            randomPosition.x = Random.Range(-0.3f, 0.3f);
            randomPosition.z = Random.Range(-0.3f, 0.3f);

            GameObject.Instantiate(
                player,
                transform.position + new Vector3((i / 2) * .8f - .4f, 0f, (float)(i % 2) * .8f - .4f) + randomPosition,
                Quaternion.identity
            );
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
