using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoCardController : MonoBehaviour
{
    public GameObject modalPanel;
    
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
    }

}
