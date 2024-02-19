using System.Collections;
using System.Collections.Generic;
using UnityEngine;
////////////////////////
//Not used at the moment
////////////////////////
public class TrainInteraction : MonoBehaviour
{
     // Reference to the ResourceManager script
    public ResourceManager resourceManager;

    // Variables for workstation interactions
    private bool isAtWorkstation = false;
    private float workstationTimer = 0f;
    private float workstationDuration = 5f; // Time it takes to complete a task at the workstation

    // Variables for storage interactions
    private bool isAtStorage = false;

    void Update()
    {
        // Check for workstation interaction
        if (isAtWorkstation)
        {
            WorkstationInteraction();
        }

        // Check for storage interaction
        if (isAtStorage)
        {
            StorageInteraction();
        }
    }

    // Example function for entering a workstation area
    public void EnterWorkstation()
    {
        isAtWorkstation = true;
    }

    // Example function for exiting a workstation area
    public void ExitWorkstation()
    {
        isAtWorkstation = false;
    }

    // Example function for interacting with a workstation
    private void WorkstationInteraction()
    {
        // Simulate a task being completed over time
        workstationTimer += Time.deltaTime;

        // Check if the task is completed
        if (workstationTimer >= workstationDuration)
        {
            // Perform actions related to completing the task
            resourceManager.ProduceFood(10); // Producing food at the workstation
            resourceManager.ProduceWater(10); // Producing water at the workstation

             // Trigger an event or animation related to completing the task
        // EventManager.TriggerEvent("WorkstationCompleted");

            
            // Reset the timer and exit the workstation
            workstationTimer = 0f;
            ExitWorkstation();
        }
    }

    //function for entering a storage area
    public void EnterStorage()
    {
        isAtStorage = true;
    }

    // function for exiting a storage area
    public void ExitStorage()
    {
        isAtStorage = false;
    }

    // function for interacting with storage
    private void StorageInteraction()
    {
        // Perform actions 
    }
}
