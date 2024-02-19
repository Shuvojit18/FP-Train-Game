using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CarriageUIManager : MonoBehaviour
{
    public GameObject interactionPanel; // Assign
    public TextMeshProUGUI interactionText; // Assign 
    private GameObject currentActivePanel;

    public GameObject enginePanel;
    public GameObject passengerPanel;

    // Vector3 savedCarriageData;
    // string savedMssg;

    private void Start(){
        if (interactionPanel == null)
        {
            Debug.LogError("Interaction Panel not assigned");
            return;
        }

        // Initially, hide the interaction panel
        interactionPanel.SetActive(false);
        currentActivePanel = null;

        enginePanel.SetActive(false);
        passengerPanel.SetActive(false);
    }
    // void refreshing(){
    //     ShowActionPanel(savedCarriageData,savedMssg)
    // }
    public void ShowInteractionPanel(Vector3 carriagePosition, string message){
         // Close any currently active panel
        if (currentActivePanel != null)
        {
            currentActivePanel.SetActive(false);
        }

        // Convert the world position of the carriage to screen position
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(carriagePosition);

        // Adjust the position above/below the carriage
        screenPosition.y += 150; // Adjust 

        // Set the position and show the panel
        interactionPanel.transform.position = screenPosition;
        interactionText.text = message; // Set the interaction text 
        interactionPanel.SetActive(true);
        currentActivePanel = interactionPanel;

    }

    public void HideInteractionPanel(){
        if (currentActivePanel != null)
        {
            currentActivePanel.SetActive(false);
            currentActivePanel = null;
        }
    }

    public void ShowActionPanel(string carriage){
        if(carriage == "Engine Carriage"){
            HideActionPanel();
            enginePanel.SetActive(true);
        } else {
            HideActionPanel();
            passengerPanel.SetActive(true);
        }
    }

    public void HideActionPanel(){
        enginePanel.SetActive(false);
        passengerPanel.SetActive(false);
    }
}
