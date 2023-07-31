using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeApp : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}
