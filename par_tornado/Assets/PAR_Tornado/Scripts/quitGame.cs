using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quitGame : MonoBehaviour
{

     // a button
    public GameObject btn;

    // get the quit button
    public void QuitGame()
    {
        Debug.Log("Quit the game clicked!");
        // quit the game
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {   
        if (btn == null){
            btn.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
              
    }
}
