using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizController : MonoBehaviour
{
    private GameManager gameManager;
    private int roundNumber = 0;
    private int score = 0;
    private List<Item> itemsList;
    private string correctAnswer;
    private string userAnswer;

    [SerializeField] 
    private TMP_Text button;
    [SerializeField] 
    private TMP_Text button1;
    [SerializeField] 
    private TMP_Text button2;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void OnEnable()
    {
        itemsList = gameManager.returnUnfoundItems();
        // itemsList = gameManager.returnFoundItems();
        button.text = itemsList[roundNumber].itemInformation;
        button1.text = itemsList[roundNumber].itemInformation;
        button2.text = itemsList[roundNumber].itemInformation;
    }

    public void option1()
    {
        userAnswer = button.text;
        checkAnswer();
    }

    public void option2()
    {
        userAnswer = button1.text;
        checkAnswer();
    }

    public void option3()
    {
        userAnswer = button2.text;
        checkAnswer();
    }

    public void checkAnswer()
    {
        if (userAnswer == correctAnswer)
        {
            score++;
            Debug.Log("Correct");
        }
        roundNumber++;
        if (roundNumber < itemsList.Count)
        {
            button.text = itemsList[roundNumber].itemInformation;
            button1.text = itemsList[roundNumber].itemInformation;
            button2.text = itemsList[roundNumber].itemInformation;
        }
        else
        {
            gameManager.SetGameState(GameState.End);
        }
    }
}
