
using UnityEngine;

public class EngineCarriage : TrainCarriage
{
    public bool isRunning = false;
    
    void Start()
    {
        CarriageType = "Engine";
        CarriageStatus = "Engine is Off";
    }

    public void isRunningToggle(){
        isRunning = !isRunning;
    }

    public override void Interact()
    {
   
        base.Interact();
        // Add Engine specific interaction logic here
       
    }

    public override string GetInteractionMessage()
    {
       // return "Controlling the train's movement.";
        if (isRunning) CarriageStatus = "Engine is Running.";
        else CarriageStatus = "Engine is Off";
        return CarriageType + " Carriage. " + CarriageStatus;
    }
 }
