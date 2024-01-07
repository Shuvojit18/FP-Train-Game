using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineCarriage : TrainCarriage
{
    public bool isRunning = true;
     void Start()
    {
        CarriageType = "Engine";
        if (isRunning) CarriageStatus = "Engine is Running.";
    }

    public override void Interact()
    {
        base.Interact();
        // Add Engine specific interaction logic here
        Debug.Log("Controlling the train's movement.");
    }
}
