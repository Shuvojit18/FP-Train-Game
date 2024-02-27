using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    private Camera mainCamera; //camera ref
    public CarriageUIManager uiManager; //UI 
    TrainCarriage carriage;
    
    public bool playerDecision;

    void Start()
    {
        mainCamera = Camera.main;
        
    }

    void Update()
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
                Debug.Log(carriage);
            }  else {
                uiManager.HideActionPanel();
                uiManager.HideInteractionPanel();
            }
        }
    }

    public void YesDecision(){
        playerDecision = true;
    }

    public void NoDecision(){
        playerDecision = false;
        uiManager.HideDecisionPanel();
    }


}
