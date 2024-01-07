using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//child of train carriage
public class StorageCarriage : TrainCarriage
{
    public ResourceManager rm; 
    //public GameObject interactionPanel;
    void Start()
    {
        CarriageType = "Storage";
    }

    public override void Interact()
    {
        base.Interact();
        int food = rm.getFood();
        int water = rm.getWater();

        CarriageStatus = "Food " + food + "  Water" + water;
        // Add Resource specific interaction logic here
        Debug.Log("Managing resources in the carriage.");
    }


}
