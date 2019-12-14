using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class InputManager : MonoBehaviour
{
    public GameInputManager gameInputManager;
    private bool settingKey;
    private KeyCode givenKeyCode;
    public int amountOfPlayers;
    public int currentPlayerNumber;
    public int currentKeyNumber;
    public TMP_Text instructionsText;
    public List<KeyCode> givenKeyCodeList;
    public bool keyHasBeenAssigned;
    public GameObject playerKeysUIElement;
    public GameObject parentUIPanel;
    public List<GameObject> UIPanelList;
    
    
    void Start()
    {
        settingKey = true;
        PopulatePlayerList(amountOfPlayers);
        StartCoroutine(WaitForKeyPress());
    }
    
    private void OnGUI()
    {
        if (settingKey)
        {
            Event keyPressEvent = Event.current;
            if (keyPressEvent.type == EventType.KeyUp)
            {
                if (keyPressEvent.isKey)
                {
                    givenKeyCode = keyPressEvent.keyCode;
                    if(givenKeyCode == KeyCode.Return)
                    {
                        SceneManager.LoadScene("Game", LoadSceneMode.Single);
                    }
                    settingKey = false;
                }
            }
        }
    }

    IEnumerator WaitForKeyPress()
    {
        Debug.Log("WaitForKeyPress started");
        for (int i = 0; i < amountOfPlayers; i++)
        {
            currentPlayerNumber = i + 1;
            //playerNumberText.SetText("Player " + currentPlayerNumber);

            for (int j = 0; j < 2; j++)
            {
                currentKeyNumber = j + 1;
                instructionsText.SetText("Press which key you want to use for key " + currentKeyNumber);
                yield return new WaitUntil(() => settingKey == false);
                bool isKeyFree = AssignKeysToPlayers(gameInputManager.listOfPlayers[currentPlayerNumber - 1], givenKeyCode, currentKeyNumber);
                if (isKeyFree == false)
                {
                    j = j-1;
                    currentKeyNumber = j + 1;
                }
                
                settingKey = true;

            }
        }
    }

    private void PopulatePlayerList(int amountOfPlayers)
    {
        for (int i = 0; i < amountOfPlayers; i++)
        {
            Player newPlayer = new Player();
            if(gameInputManager.listOfPlayers == null)
                gameInputManager.listOfPlayers = new List<Player>();
            gameInputManager.listOfPlayers.Add(newPlayer);
            
        }
    }
    public bool AssignKeysToPlayers(Player player, KeyCode keyCode, int keyNumber)
    {
        //keyNumber 1 on playerKey_1, keyNumber 2 on playerKey_2
        bool isKeyFree = CheckIfKeyInUse(keyCode);
        if (isKeyFree)
        {
            if (keyNumber == 1)
            {
                player.playerKey_1 = keyCode;   
                givenKeyCodeList.Add(keyCode);
                Debug.Log("assigned :" + keyCode + " to player " + currentPlayerNumber + " for key " + currentKeyNumber);
                //assignedKeyText_1.SetText("The key you chose as your first key is " + givenKeyCode);
                
            } else if (keyNumber == 2)
            {
                givenKeyCodeList.Add(keyCode);
                player.playerKey_2 = keyCode;
                Debug.Log("assigned :" + keyCode + " to " + currentPlayerNumber + " for key " + currentKeyNumber);
                //assignedKeyText_2.SetText("The key you chose as your second key is " + givenKeyCode);
                player.playerNumber = currentPlayerNumber;
                CreatePanelForPlayer(player);
            }

            return isKeyFree;
        } else
        {
            Debug.Log("Error error!");
            return isKeyFree;
        }

    }

    public bool CheckIfKeyInUse(KeyCode keyCode)
    {
        bool isKeyFree = true;
        for (int i = 0; i < givenKeyCodeList.Count; i++)
        {
            if (keyCode == givenKeyCodeList[i])
            {
                isKeyFree = false;
            }
            else
            {
                isKeyFree = true;
            }
        }
        return isKeyFree;
    }

    public void CreatePanelForPlayer(Player player)
    {
        //luodaan myös uusi UI elementti jokaiselle pelaajalle
        GameObject newPlayerUIElement = Instantiate(playerKeysUIElement);
        Vector3 panelPosition = new Vector3(-600 + (player.playerNumber * 300 - 300),300,0);
        
        newPlayerUIElement.GetComponent<PlayerInputInfo>().playerNumberText.SetText("Player " + player.playerNumber);
        newPlayerUIElement.GetComponent<PlayerInputInfo>().assignedKeyText_1.SetText("Key 1: " + player.playerKey_1);
        newPlayerUIElement.GetComponent<PlayerInputInfo>().assignedKeyText_2.SetText("Key 2: " + player.playerKey_2);
        newPlayerUIElement.GetComponent<PlayerInputInfo>().panelUI.transform.SetParent(parentUIPanel.transform);
        newPlayerUIElement.GetComponent<PlayerInputInfo>().panelUI.anchoredPosition = panelPosition;
        Destroy(newPlayerUIElement);
        UIPanelList.Add(newPlayerUIElement);
    }
    
}
