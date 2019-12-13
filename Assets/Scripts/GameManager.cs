using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int amountOfPlayers;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //asetetaan pelaajan valitsema näppäin
    public void AssignKeysToPlayers(Player player, KeyCode keyCode, int keyNumber)
    {
        //keyNumber 1 on playerKey_1, keyNumber 2 on playerKey_2
        if (keyNumber == 1)
        {
            player.playerKey_1 = keyCode;            
        } else if (keyNumber == 2)
        {
            player.playerKey_2 = keyCode;
        }

    }
}
