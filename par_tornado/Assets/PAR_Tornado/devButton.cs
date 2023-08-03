using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class devButton : MonoBehaviour
{
    public GameObject button;
    public GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        button = GameObject.Find("devButtonEnd");
    }

    public void OnDevButtonClick() {
        Debug.Log("Dev button clicked");
        gameManager.SetGameState(GameState.End);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
