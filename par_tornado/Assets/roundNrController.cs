using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class roundNrController : MonoBehaviour
{
    [SerializeField] 
    private TMP_Text progressNrText;

    private GameManager gameManager;

    private void Awake()
    {            
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();         
    }

    private void Update()
    {
        if (progressNrText != null){
            progressNrText.text = gameManager.getRoundNumber() + "/5";
        }
        else {
            Debug.LogWarning("progressNrText is null.");
        }
    }
}
