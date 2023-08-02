using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endScreenController : MonoBehaviour
{
    public GameObject endScreenPrefab;

    // Start is called before the first frame update
    void showEndScreen()
    {
        // set the endscreen prefab to active
        endScreenPrefab.SetActive(true);
    }       
}