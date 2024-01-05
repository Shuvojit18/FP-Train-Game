using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//child class of train carriage
public class PassengerCarriage : TrainCarriage
{
    public int PassengerCount { get; private set; }

    void Start()
    {
        CarriageType = "Passenger";
        PassengerCount = 10; // passenger count, can be set differently
    }

    public override void Interact()
    {
        base.Interact();
        // Add Passenger specific interaction logic here
        Debug.Log("Checking on " + PassengerCount + " passengers.");
    }
}
