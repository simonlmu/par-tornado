using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoCardController : MonoBehaviour
{
    public GameObject modalPanel;
    public GameObject hintPanel;
    
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void Continue()
    {
        if(modalPanel != null)
        {
            modalPanel.SetActive(false);
        }
        if (!gameManager.getCurrentState().Equals(GameState.Gameplay) ){
            gameManager.SetGameState(GameState.Gameplay);
        }
        if(hintPanel != null)
        {
            hintPanel.SetActive(true);
        }
    }

}
