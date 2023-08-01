using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ModalController : MonoBehaviour
{
    public GameObject modalPanel;
    public GameObject button;
    
    [SerializeField] 
    private TMP_Text _hints;

    public GameObject infoBoxPrefab; // Reference to your AR info box prefab
    private InfoBoxController infoBoxController; // Reference to the ARInfoBoxController component


    private int counter;

    private void setModalText(string text)
    {
        if(_hints != null)
        {
            _hints.text = text;
        }

        if (infoBoxController == null)
        {
            // Instantiate the AR info box prefab and get its ARInfoBoxController component
            // GameObject arInfoBox = Instantiate(infoBoxPrefab, transform.position, transform.rotation);
            infoBoxController = FindObjectOfType<InfoBoxController>();
        }

        if (infoBoxController != null)
        {
            // Update the text in the info box
            infoBoxController.SetInfoText(text);
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