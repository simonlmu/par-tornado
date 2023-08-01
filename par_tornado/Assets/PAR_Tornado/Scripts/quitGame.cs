using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quitGame : MonoBehaviour
{

     // a button
    public Button btn;
       
    // get the quit button
    public void QuitGame()
    {
        // quit the game
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
