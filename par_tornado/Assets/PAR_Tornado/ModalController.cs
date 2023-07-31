using UnityEngine;
using UnityEngine.UI;

public class ModalController : MonoBehaviour
{
    public GameObject modalPanel;

    public void ShowModal()
    {
        if(modalPanel != null)
        {
            modalPanel.SetActive(true);
        }
    }

    public void HideModal()
    {
        if(modalPanel != null)
        {
            modalPanel.SetActive(false);
        }
    }

    public void ToggleModal()
    {
        if(modalPanel != null)
        {
            modalPanel.SetActive(!modalPanel.activeSelf);
        }
    }
}