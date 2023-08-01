using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ModalController : MonoBehaviour
{
    public GameObject modalPanel;
    public GameObject button;

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
    }
}