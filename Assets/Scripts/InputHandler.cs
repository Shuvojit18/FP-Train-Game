using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    private Camera mainCamera; //camera ref
    public CarriageUIManager uiManager; //UI 
    TrainCarriage carriage;
    // EngineCarriage engine;
    // Panel enginePanel;
    void Start()
    {
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found");
        }
    }

    void FixedUpdate()
    {   //checking if there is a mouse click and main camera present
        if (Input.GetMouseButtonDown(0) && mainCamera != null)
        {
           PerformRaycast();   //performing raycast
            
        }
    }

    private void PerformRaycast()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
           // getting the train carriage
            carriage = hit.transform.GetComponent<TrainCarriage>();   
            if (carriage != null)
            {
                carriage.Interact();    //calling interact();
                string message = carriage.GetInteractionMessage(); // Method to get the message
                uiManager.ShowInteractionPanel(hit.transform.position, message);//showing panel + text
                uiManager.ShowActionPanel(carriage.name);
            }  else {
                uiManager.HideActionPanel();
                uiManager.HideInteractionPanel();
            }
        }
    }


}
