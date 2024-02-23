using UnityEngine;

public class EnginePanelTrigger : MonoBehaviour
{
    public GameObject enginePanel;

    private void OnTriggerEnter(Collider other)
    {
        // Check for the  player
        if (other.CompareTag("Player")) // Ensure the "Player" tag
        {
            // Show the UI panel
            enginePanel.SetActive(true);
           
        }
    }

    // private void OnTriggerExit(Collider other)
    // {
    //     if (other.CompareTag("Player") )
    //     {
    //         enginePanel.SetActive(false);// Hide the UI panel
    //     }
    // }
}
