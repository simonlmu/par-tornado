using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class GameManager : MonoBehaviour
{
    // initialize gameState , set it to menu
    private GameState currentState = GameState.Menu;

    // List of all items
    public List<Item> itemsList = new List<Item>();

    // add items to the list
    private void awake(){
        itemsList.Add(new Item("PC", false, "This is a PC"));
        itemsList.Add(new Item("Laptop", false, "This is a Laptop"));
        // ... 
    }

    public List<Item> GetItemsList(){
        return itemsList;
    }

    // Start is called before the first frame update
    void Start()
    {
        // set the first game state to menu
        currentState = GameState.Menu;
    }

    

    public void StartGame()
    {
        SetGameState(GameState.Gameplay);
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
                returnUnfoundItems();
                
                // if not all items have been found
                // chose an item randomly from these
                chooseRandomItem(returnUnfoundItems());

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
    }

    // function to show the end screen
    public void showEndScreen(){ // ToDo
        // show the end screen
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
        if (returnUnfoundItems().Count == 0)
                {
                    SetGameState(GameState.End);
                }
        return unfoundItems;

    }

    // function to choose a random item from the unfound items
    public Item chooseRandomItem(List<Item> unfoundItems){
        int randomIndex = Random.Range(0, unfoundItems.Count);
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
    public string itemDescription;

    public Item(string name, bool isCollected, string itemDescription)
    {
        this.itemName = name;
        this.isCollected = isCollected;
        this.itemDescription = itemDescription;
    }
}