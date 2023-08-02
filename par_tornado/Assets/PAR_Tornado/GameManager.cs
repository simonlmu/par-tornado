using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;


public class GameManager : MonoBehaviour
{
    // Endscreen stuff
    [SerializeField]
    public GameObject endScreenPrefab;

    // track time for highscores
    private float startTime;
    private float elapsedTime;

    // list of highscores
    private List<float> highscores = new List<float>();

    public static GameManager instance;
    // initialize gameState , set it to menu
    private GameState currentState = GameState.Menu;

    // List of all items
    public List<Item> itemsList = new List<Item>();
    private List<Item> unfoundItems = new List<Item>();
    public Item currentItem;

    [SerializeField]
    private TMP_Text _hints;

    // add items to the list
    private void Awake(){
        instance = this;
        startTime = Time.time;
        itemsList.Add(new Item("chip", false, "Ich bin golden, ...", "Der Computerchip besteht ..."));
        itemsList.Add(new Item("licht", false, "Ich bin schwarz und leuchte ... ", "Das einfache Fahrradlicht besteht..."));
        itemsList.Add(new Item("grafikkarte", false, "Ich bin ein Teil des Computers, ...", "Die Grafikkarte ist ein Teil des Computers, ..."));
        itemsList.Add(new Item("klavier", false, "Ich bin ein Spielzeug, ...", "Das Kinder Klavier ist ein Spielzeug, ..."));
        itemsList.Add(new Item("nokia", false, "Ich bin ein elektronisches Gerät, ...", "Das Handy ist ein elektronisches Gerät, ..."));
        itemsList.Add(new Item("uhr", false, "Ich bin ein Accessoire, ...", "Die Armbanduhr ist ein Accessoire, ..."));
        // ... 
    }

    // function to get the full items' list
    public List<Item> GetItemsList(){
        return itemsList;
    }

    // Start is called before the first frame update
    // sets the first game state to menu
    void Start()
    {
        currentState = GameState.Menu;
    }

    public void StartGame()
    {
        SetGameState(GameState.Gameplay);
    }

    private void Update(){
        elapsedTime = Time.time - startTime;
    }

    // elapsed time for highscoring
    public float GetElapsedTime()
    {
        return elapsedTime;
    }

    public void RestartGame(){
        // set all items to not found
        foreach (Item item in itemsList)
        {
            item.isCollected = false;
        }
        // set game state to menu
        SetGameState(GameState.Menu);
        Debug.Log("Game restart successful!");
    }
    public void EndGame()
    {
        SetGameState(GameState.End);
    }

    private void SetGameState(GameState newState)
    {   
        currentState = newState;
        switch (currentState)
        {
            case GameState.Menu:
                 // checks which items have been found already
                // if all items have been found go to GameState.End
                var unfoundItems = returnUnfoundItems();
                
                // if not all items have been found
                // chose an item randomly from these
                currentItem = chooseRandomItem(unfoundItems);
                setHints(currentItem.itemHint);

                // Explain the item that needs to be found to the user
                // use the description of the item for that

                // show button to start/continue the game
                showButton();

                break;

            case GameState.Gameplay:
                // opening the game scene where player finds the item
                // if player found it save it to the list of found items
                // go back to menu
                break;

            case GameState.End:
                // show our end screen
                showEndScreen();
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

    // function to show the end screen
    public void showEndScreen(){ 
        // Instantiate the end screen canvas prefab only if it is not already instantiated.
        GameObject endScreen = Instantiate(endScreenPrefab, Vector3.zero, Quaternion.identity);
        // Ensure the end screen canvas is visible.
        endScreen.SetActive(true);
        
        Debug.Log("End screen set to active");
    }

    // change game state when player finds an item
    public void itemFound(string itemName)
    {
        setItemStatus(itemName, true);
        SetGameState(GameState.Menu);
    }
    
    // function to return unfound items
    public List<Item> returnUnfoundItems(){
        List<Item> unfoundItems = new List<Item>();
        foreach (Item item in itemsList)
        {
            if (!item.isCollected)
            {
                unfoundItems.Add(item);
            }
        }
        if (itemsList.Count == 0)
        {
            SetGameState(GameState.End);
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

    // function to show the button
    public void showButton(){
        // show the button // ToDo
    }

    public void setHints(string text)
    {
        if(_hints != null)
        {
            _hints.text = text;
        }
    }

    public Item getCurrentItem()
    {
        return currentItem;
    }
}

// Defining the game states
public enum GameState
    {  
        // Game States
        Menu,
        Gameplay,
        End        
    }

// Defining Item class
[System.Serializable]
public class Item
{
    public string itemName;
    public bool isCollected;
    public string itemHint;
    public string itemInformation;

    public Item(string name, bool collected, string hint, string info)
    {
        this.itemName = name;
        this.isCollected = collected;
        this.itemHint = hint;
        this.itemInformation = info;
    }
}