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
    private TMP_Text question;
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
        itemsList = gameManager.returnFoundItems();
        
        setQuestion(itemsList[roundNumber]);
    }

    public void setQuestion(Item item)
    {
        var options = item.itemAnswers;
        correctAnswer = options[0];

        ShuffleList(options);
        question.text = item.itemQuestion;
        button.text = options[0];
        button1.text = options[1];
        button2.text = options[2];
    }

    public void checkAnswer()
    {
        if (userAnswer == correctAnswer)
        {
            score++;
            gameManager.setQuizScore(score);
        }
        roundNumber++;
        if (roundNumber < itemsList.Count)
        {
            setQuestion(itemsList[roundNumber]);
        }
        else
        {
            gameManager.SetGameState(GameState.End);
        }
    }
    
    public void ShuffleList(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            string temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
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
}
