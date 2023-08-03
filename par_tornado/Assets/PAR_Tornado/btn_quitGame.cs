using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btn_quitGame : MonoBehaviour
{
    public GameObject button;
    // Start is called before the first frame update
    private void Awake()
    {
        button = GameObject.Find("btn_quit");
    }

    public void OnQuitButtonClick() {
        Application.Quit();
        Debug.Log("End of Application");
    }

}
