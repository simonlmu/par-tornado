using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndCanvasController : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField]
    private TMP_Text scoreText;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnEnable()
    {
        scoreText.text = "Du hast " + gameManager.getQuizScore() + "/3 Fragen richtig beantwortet." ;
    }
}