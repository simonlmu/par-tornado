using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ModalController : MonoBehaviour
{
    public GameObject modalPanel;
    public GameObject button;
    
    [SerializeField] 
    private TMP_Text _hints;

    private int counter;

    private void setModalText(string text)
    {
        if(_hints != null)
        {
            _hints.text = text;
        }

        counter++;
    }

    public void ShowModal()
    {
        if(modalPanel != null)
        {
            modalPanel.SetActive(true);
        }
        if(button != null)
        {
            button.SetActive(false);
        }
        setModalText("Modal: " + counter);
    }

    public void HideModal()
    {
        if(modalPanel != null)
        {
            modalPanel.SetActive(false);
        }
        if(button != null)
        {
            button.SetActive(true);
        }
    }

    public void ToggleModal()
    {
        if(modalPanel != null)
        {
            modalPanel.SetActive(!modalPanel.activeSelf);
        }
        if(button != null)
        {
            button.SetActive(!button.activeSelf);
        }
        setModalText("Modal: " + counter);
    }
}