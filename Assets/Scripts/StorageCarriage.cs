using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//child of train carriage
public class StorageCarriage : TrainCarriage
{
   void Start()
    {
        CarriageType = "Resource";
    }

    public override void Interact()
    {
        base.Interact();
        // Add Resource specific interaction logic here
        Debug.Log("Managing resources in the carriage.");
    }
}
