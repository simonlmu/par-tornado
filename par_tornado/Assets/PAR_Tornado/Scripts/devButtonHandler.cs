using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class devButtonHandler : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        // Find the GameManager as GameObject in the scene.
       //  gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void OnButtonClick()
    {
        // Interact with the GameManager to change the game state to GameState.End
        if (gameManager != null)
        {
            gameManager.EndGame();
        }
    }
}
