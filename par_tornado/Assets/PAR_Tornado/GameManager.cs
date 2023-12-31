using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;


public class GameManager : MonoBehaviour
{
    private float timer = 0f;
    private bool isTimerRunning = false;

    private float timeLimit = 60f;
    private int hints = 1;

    private int quizScore = 0;

    public int roundNumer = 0;

    // End canvas for end screen
    [SerializeField]
    public GameObject endCanvas;

    [SerializeField]
    public GameObject startCanvas;

    [SerializeField]
    public GameObject quizCanvas;
    [SerializeField]
    public GameObject quizButton;

    [SerializeField]
    public GameObject hintButton;
    [SerializeField]
    public GameObject hintPanel;

    [SerializeField]
    public GameObject note_found;
    public GameObject infoModal; 
    public GameObject particlesScript;

    public static GameManager instance;
    // initialize gameState , set it to menu
    private GameState currentState = GameState.Start;

    // List of all items
    public List<Item> itemsList = new List<Item>();
    public Item currentItem;

    [SerializeField]
    private TMP_Text _hints;

    // Singleton pattern
    private void Awake(){
        isTimerRunning = true;
       // Ensure there is only one instance of the GameManager in the scene.
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // function to get the full items' list
    public List<Item> GetItemsList(){
        return itemsList;
    }

       private System.Collections.IEnumerator showNotefor2Seconds()
    {
        note_found.SetActive(true);
   //     particlesScript.PlayCelebrationEffect();

        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);

        // Deactivate the canvas
        note_found.SetActive(false);
        infoModal.SetActive(true);
    }

    // Start is called before the first frame update
    // sets the first game state to menu
    void Start()
    {
        SetGameState(GameState.Menu);
        Debug.Log("The current state is " + currentState);
    }

    void Update(){
        // Check if the timer is running and update the elapsed time.
        if (isTimerRunning)
        {
            timer += Time.deltaTime;
        }
    }

    private void StopTimer()
    {
        // Call this method to stop the timer.
        isTimerRunning = false;
    }

    public float getElapsedTime()
    {
        // Call this method to get the elapsed time.
        return timer;
    }

    public void SetGameState(GameState newState)
    {   
        currentState = newState;
        switch (currentState)
        {
            case GameState.Start:
                // show the start screen
                // if(startCanvas != null)
                // {
                //     startCanvas.SetActive(true);
                //     Debug.Log("Start Screen is active");
                // }
                break;

            case GameState.Menu:
                endStartScreen();
                // opening the game scene where player finds the item
                // if player found it save it to the list of found items
                // go back to menu
                break;

            case GameState.Gameplay:

                if(roundNumer == 3) {
                    SetGameState(GameState.Quiz);
                    break;
                }

                 // checks which items have been found already
                // if all items have been found go to GameState.End
                var unfoundItems = returnUnfoundItems();
                
                // if not all items have been found
                // chose an item randomly from these
                currentItem = chooseRandomItem(unfoundItems);
                hints = 1;
                hintButton.SetActive(true);
                setHints();

                break;

            case GameState.Quiz:
                // show the quiz screen
                if (quizButton != null)
                {
                    quizButton.SetActive(true);
                }
                if (hintPanel != null)
                {
                    hintPanel.SetActive(false);
                }
                break;

            case GameState.End:
                quizCanvas.SetActive(false);
                // stop the timer
                StopTimer();
                // show our end screen
                showEndScreen();
                // set round number to 1
                roundNumer = 1;
                break;

            case GameState.PostGame:
                endCanvas.SetActive(false);
                // show the post game screen
                break;

            default:
                Debug.LogWarning("Unknown game state: " + currentState);
                break;
        }

        // notify that state has changed if it has changed
        if (currentState != newState){
            Debug.Log("Game state changed from " + currentState + " to " + newState);
          
        }
    }

    // function to end StartScreen
    public void endStartScreen(){
        startCanvas.SetActive(false);
    }    

    public void showQuizScreen(){
        if(quizCanvas != null)
        {
            quizCanvas.SetActive(true);
            quizButton.SetActive(false);
        }
    }
    
    // function to show the end screen
    public void showEndScreen(){
        if(endCanvas != null)
        {
            endCanvas.SetActive(true);
        }
    }


    // change game state when player finds an item
    public void itemFound(string itemName)
    {
        setItemStatus(itemName, true);
        // increase round number
        roundNumer++;
        StartCoroutine(showNotefor2Seconds());
    }

    public int getRoundNumber()
    {
        return roundNumer;
    }

    public List<Item> returnFoundItems(){
        List<Item> foundItems = new List<Item>();
        foreach (Item item in itemsList)
        {
            if (item.isCollected)
            {
                foundItems.Add(item);
            }
        }
        return foundItems;
    }

    // function to return unfound items
    public List<Item> returnUnfoundItems(){
        List<Item> unfoundItems = new List<Item>();
        List<Item> foundItems = new List<Item>();
        foreach (Item item in itemsList)
        {
            if (!item.isCollected)
            {
                unfoundItems.Add(item);
            }
            else
            {
                foundItems.Add(item);
            }
        }
        // first time of playing, start the timer
        if (foundItems.Count == 0)
        {
            isTimerRunning = true;
        }
        return unfoundItems;
    }

    // function to choose a random item from the unfound items
    public Item chooseRandomItem(List<Item> unfoundItems){
        int randomIndex = UnityEngine.Random.Range(0, unfoundItems.Count);
        Item randomItem = unfoundItems[randomIndex];
        return randomItem;
    }

    // function to set a specific item to be found
    public void setItemStatus(string itemName, bool isCollected){
        // Find the item in the itemsList
        Item itemToUpdate = itemsList.Find(item => item.itemName == itemName);

        // If the item is found, update its isCollected status
        if (itemToUpdate != null)
        {
            itemToUpdate.isCollected = isCollected;
        }
        else
        {
            Debug.LogWarning("Item not found: " + itemName);
        }
    }

    public void addHint()
    {
        if(hints > currentItem.itemHint.Count)
        {
            return;
        }
        hints++;
        if(hints == currentItem.itemHint.Count)
        {
            hintButton.SetActive(false);
        }
        setHints();
    }

    public void setHints()
    {
        if (currentItem == null || currentItem.itemHint == null)
        {
            return;
        }
        var text = "• " + string.Join(Environment.NewLine + "• ", currentItem.itemHint.GetRange(0, hints));
        
        if(_hints != null)
        {
            _hints.text = text;
        }
    }

    public Item getCurrentItem()
    {
        return currentItem;
    }

    public GameState getCurrentState(){
        Debug.Log("The current state is " + currentState);
        return currentState;
    }

    public void setPostGameState()
    {
        SetGameState(GameState.PostGame);
    }
    
    public int getQuizScore()
    {
        return quizScore;
    }

    public void setQuizScore(int score)
    {
        quizScore = score;
    }
}


// Defining the game states
public enum GameState
    {  
        // Game States
        Start,
        Menu,
        Gameplay,
        End, 
        Quiz,
        PostGame
    }

// Defining Item class
[System.Serializable]
public class Item
{
    public string itemName;
    public bool isCollected;
    public List<string> itemHint;
    public string itemInformation;
    public string imageName;
    public string itemQuestion;
    public List<string> itemAnswers;
}