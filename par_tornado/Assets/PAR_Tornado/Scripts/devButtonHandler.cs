using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class devButtonHandler : MonoBehaviour
{
    public GameManager gameManager;
    public Button button;
    
    private void Start()
    {
        
    }

    public void OnDevButtonClick()
    {
        // Interact with the GameManager to change the game state to GameState.End
        if (gameManager != null)
        {
            gameManager.EndGame();
        }
    }
}