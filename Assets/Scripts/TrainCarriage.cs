using UnityEngine;

public class TrainCarriage : MonoBehaviour
{
    public string CarriageType { get; protected set; }// this code is adapted from unity forum. (https://discussions.unity.com/t/what-is-the-difference-between-private-and-protected/91775)
    public string CarriageStatus { get; protected set; }

    // This method can be overridden by specific carriage types for custom interaction logic
    public virtual void Interact()
    {
       // Debug.Log("Interacting with " + CarriageType + " Carriage.");
        
       // return "Interacting with Carriage.";
    }

    public virtual string GetInteractionMessage()
    {
        return CarriageType + " Carriage " + CarriageStatus;
    }
}
