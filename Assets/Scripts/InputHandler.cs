using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Camera mainCamera; //camera ref
    public CarriageUIManager uiManager; //UI 
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found");
        }
    }

    // Update is called once per frame
    void Update()
    {   // can be optimized
        // Check if the left mouse button was clicked
        // if (Input.GetMouseButtonDown(0))
        // {
        //     RaycastHit hit;
        //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //     // Perform the raycast
        //     if (Physics.Raycast(ray, out hit))
        //     {
        //         // Check if the raycast hit a train carriage
        //         TrainCarriage carriage = hit.transform.GetComponent<TrainCarriage>();
        //         if (carriage != null)
        //         {
        //             // Call the interact method on the carriage
        //             carriage.Interact();
        //         }
        //     }
        // }

        //checking if there is a mouse click and main camera present
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
            TrainCarriage carriage = hit.transform.GetComponent<TrainCarriage>();   
            
            if (carriage != null)
            {
                carriage.Interact();    //calling interact();
                //uiManager.ShowInteractionPanel(hit.transform.position); //showing panel
                string message = carriage.GetInteractionMessage(); // Method to get the message
                uiManager.ShowInteractionPanel(hit.transform.position, message);//showing panel + text
            }
        }
    }


}
