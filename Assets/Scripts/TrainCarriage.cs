using UnityEngine;

public class TrainCarriage : MonoBehaviour
{
    public string CarriageType { get; protected set; }// this code is copied from unity forum. (https://discussions.unity.com/t/what-is-the-difference-between-private-and-protected/91775)

    // This method can be overridden by specific carriage types for custom interaction logic
    public virtual void Interact()
    {
        Debug.Log("Interacting with " + CarriageType + " Carriage.");
        //return "Interacting with Carriage.";
    }

    public string GetInteractionMessage()
    {
        return CarriageType + " Carriage.";
    }
}
