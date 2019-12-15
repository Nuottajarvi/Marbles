using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputManager : MonoBehaviour
{

    public List<Player> listOfPlayers;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if(listOfPlayers == null)
            listOfPlayers = new List<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
