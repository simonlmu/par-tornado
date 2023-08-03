using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public GameObject StartCanvasPanel;
    public GameObject button;

    public void StartGame()
    {
       // gameManager.SetGameState(GameState.Menu);
        Debug.Log("Start Game Button Pressed");
    }
 }
