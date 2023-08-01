using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoBoxController : MonoBehaviour
{
    [SerializeField] 
    private TMP_Text _infoText;

    public void SetInfoText(string text)
    {
        if (_infoText != null)
        {
            _infoText.text = text;
        }
    }
}
