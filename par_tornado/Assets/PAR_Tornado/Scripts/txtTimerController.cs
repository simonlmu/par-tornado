using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class txtTimerController : MonoBehaviour
{
    public GameObject textGO2;

    private Text timerText;

    private float elapsedTime = 0f;
    
    public GameManager gameManager;

private void Awake()
    {
        GameObject textGO = textGO2;
        timerText = textGO.GetComponent<Text>();
        gameManager = FindObjectOfType<GameManager>();
 
    }

   private void Start()
    {
        // Find the Text component attached to the UI Text object.
        // timerText = GetComponent<Text>();
        elapsedTime = gameManager.getElapsedTime();
        timerText.text = FormatTime(elapsedTime);
        Debug.Log("The elapsed time is " + timerText.text);
    }

    private string FormatTime(float timeInSeconds)
    {
        // Convert the time in seconds to a formatted string (e.g., "00:00.00").
        int minutes = Mathf.FloorToInt(timeInSeconds / 60f);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60f);
        int milliseconds = Mathf.FloorToInt((timeInSeconds * 100f) % 100f);
        return string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, milliseconds);
    }
}
