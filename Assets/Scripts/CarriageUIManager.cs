using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CarriageUIManager : MonoBehaviour
{
    public GameObject interactionPanel; // Assign
    public TextMeshProUGUI interactionText; // Assign 
    private GameObject currentActivePanel;

    private void Start()
    {
        if (interactionPanel == null)
        {
            Debug.LogError("Interaction Panel not assigned");
            return;
        }

        // Initially, hide the interaction panel
        interactionPanel.SetActive(false);
        currentActivePanel = null;
      
 
    }

    public void ShowInteractionPanel(Vector3 carriagePosition, string message)
    {
         // Close any currently active panel
        if (currentActivePanel != null)
        {
            currentActivePanel.SetActive(false);
        }

        // Convert the world position of the carriage to screen position
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(carriagePosition);

        // Adjust the position above or below the carriage
        screenPosition.y += 150; // Adjust this value as needed

        // Set the position and show the panel
        interactionPanel.transform.position = screenPosition;
        interactionText.text = message; // Set the interaction text
        interactionPanel.SetActive(true);
        currentActivePanel = interactionPanel;

    }

    public void HideInteractionPanel()
    {
        if (currentActivePanel != null)
        {
            currentActivePanel.SetActive(false);
            currentActivePanel = null;
        }
    }
}
