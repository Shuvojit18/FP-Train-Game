using UnityEngine;

public class EnginePanelTrigger : MonoBehaviour
{
    public GameObject enginePanel;
    public GameObject player;
    public GameObject enginePanelLight;
    public GameObject engineLight1;
    public GameObject engineLight2;
    public AudioSource switches; // Assign

    void Start(){
        enginePanelLight.SetActive(false);
        engineLight1.SetActive(false);
        engineLight2.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        // Check for the  player
        if (other.CompareTag("Player")) // Ensure the "Player" tag
        {
            switches.Play();
            // Show the UI panel
            enginePanel.SetActive(true);
            player.SetActive(false);
            
            
            engineLight1.SetActive(true);

            Invoke("Delayed1Sec", 1f); // Calls method 
            Invoke("Delayed2Sec", 2f); // Calls method 

           
        }
    }

    void Delayed1Sec() {
        engineLight2.SetActive(true); 
    }

    void Delayed2Sec() {
        enginePanelLight.SetActive(true);
    }

    // private void OnTriggerExit(Collider other)
    // {
    //     if (other.CompareTag("Player") )
    //     {
    //         enginePanel.SetActive(false);// Hide the UI panel
    //     }
    // }
}
