using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoBoxController : MonoBehaviour
{
    [SerializeField] 
    private TMP_Text _infoTitle;

    private GameObject infoModal;
    private string _infoText;
    
    public void SetInfoText(string text)
    {
        _infoText = text;
    }

    public void SetInfoTitle(string text)
    {
        if (_infoTitle != null)
        {
            _infoTitle.text = text;
        }
    }

    public void setInfoModal(GameObject modal)
    {
        infoModal = modal;
    }

    public void showInfoModal()
    {
        infoModal.SetActive(true);
        var infoModalController = infoModal.GetComponent<InfoBoxController>();
        infoModalController.SetInfoTitle(_infoText);
    }
}
