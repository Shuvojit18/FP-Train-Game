using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//child class of train carriage
public class PassengerCarriage : TrainCarriage
{
    public int PassengerCount { get; private set; }
    public float PassengerMorale { get; private set; }
    public float PassengerHealth { get; private set; }

    // if we require more than 1 passenger car this may come in handy
    // public PassengerCarriage(int initialPassengers)
    // {
    //     PassengerCount = initialPassengers;
    //     PassengerMorale = 100; // Start with full morale
    //     PassengerHealth = 100; // Start with full health
    // }

   

    void Start()
    {
        CarriageType = "Passenger";
        PassengerCount = 10; // passenger count, can be set differently
        PassengerMorale = 100; // Start with full morale
        PassengerHealth = 100; // Start with full health

    }

    public override void Interact()
    {
        base.Interact();
        // Add Passenger specific interaction logic here
        CarriageStatus = PassengerCount + " Passengers. " + " Health - " + PassengerHealth  + " Morale - " + PassengerMorale;

        //Debug.Log("Checking on " + PassengerCount + " passengers.");
    }

     // Call this method to distribute food to passengers
    public void DistributeFood(int foodAmount)
    {
        // Implement logic to affect passenger morale and health based on food distribution
        // Example: Increase morale and health if food is sufficient
    }

    // Call this method to distribute water to passengers
    public void DistributeWater(int waterAmount)
    {
        // Similar implementation as DistributeFood
    }
}
