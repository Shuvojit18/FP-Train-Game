using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineCarriage : TrainCarriage
{
     void Start()
    {
        CarriageType = "Engine";
    }

    public override void Interact()
    {
        base.Interact();
        // Add Engine specific interaction logic here
        Debug.Log("Controlling the train's movement.");
    }
}
