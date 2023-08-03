using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class txtTimerController : MonoBehaviour
{
    [SerializeField] 
    private TMP_Text _infoText;
    
    private GameManager gameManager;

private void Awake()
    {            
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();

        if (_infoText != null){
            _infoText.text = FormatTime(gameManager.getElapsedTime());
        }
        else {
            Debug.LogWarning("_infoText is null.");
        }
         
        Debug.Log("Awake - elapsed time: " + _infoText.text);
    }

   private void Update()
    {
        // Find the Text component attached to the UI Text object.
        // timerText = GetComponent<Text>();
        // elapsedTime = gameManager.getElapsedTime();
        // Debug.Log("The elapsed time is " + timerText.text);
    }

    private string FormatTime(float timeInSeconds)
    {
        // Convert the time in seconds to a formatted string (e.g., "00:00.00").
        int minutes = Mathf.FloorToInt(timeInSeconds / 60f);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
