using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartButtonController : MonoBehaviour
{
    public Button btn_restart;
    public GameManager gameManager;

    public void OnRestartButtonClick()
    {
        // Interact with the GameManager to change the game state to GameState.End
        if (gameManager != null)
        {   
            Debug.Log("Restart the game clicked!");
            gameManager.RestartGame();
        }
    }
}
