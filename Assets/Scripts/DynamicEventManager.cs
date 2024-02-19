using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicEventManager : MonoBehaviour
{
    // Reference to the ResourceManager script
    public ResourceManager resourceManager;

    // event types
    public enum EventType
    {
        FoodShortage,
        WaterShortage,
        EnergyCrisis
        // Add more event types 
    }

    // Example event probabilities (0 to 1)
    public float foodShortageProbability = 0.1f;
    public float waterShortageProbability = 0.1f;
    public float energyCrisisProbability = 0.05f;

    void Update()
    {
        // Simulate random events over time
        //SimulateRandomEvent();
    }

    // void SimulateRandomEvent()
    // {
    //     // Generate a random number between 0 and 1
    //     float randomValue = Random.value;

    //     // Check if a dynamic event occurs based on probabilities
    //     if (randomValue < foodShortageProbability)
    //     {
    //         TriggerEvent(EventType.FoodShortage);
    //     }
    //     else if (randomValue < waterShortageProbability)
    //     {
    //         TriggerEvent(EventType.WaterShortage);
    //     }
    //     else if (randomValue < energyCrisisProbability)
    //     {
    //         TriggerEvent(EventType.EnergyCrisis);
    //     }
    // }

    void TriggerEvent(EventType eventType)
    {
        // Perform actions based on the triggered event
        switch (eventType)
        {
            case EventType.FoodShortage:
                //Reduce food 
                resourceManager.ConsumeFood(20);
                Debug.Log("Food shortage event!");
                break;

            case EventType.WaterShortage:
                //Reduce water
                resourceManager.ConsumeWater(15);
                Debug.Log("Water shortage event!");
                break;

            case EventType.EnergyCrisis:
                //Reduce energy 
                //resourceManager.ConsumeEnergy(30);
                Debug.Log("Energy crisis event!");
                break;

            // Add more cases for additional event types

            default:
                Debug.LogWarning("Unknown event type");
                break;
        }
    }
}