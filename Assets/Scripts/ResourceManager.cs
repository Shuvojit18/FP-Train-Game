using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    // Resource variables
    private int food = 100;
    private int water = 100;
    private int energy = 100;

    // Resource consumption rates
    private int foodConsumptionRate = 5;
    private int waterConsumptionRate = 7;
    private int energyConsumptionRate = 10;

    // Resource production rates
    private int foodProductionRate = 3;
    private int waterProductionRate = 5;
    private int energyProductionRate = 8;

    void Update()
    {
        // Simulate resource consumption over time
        //ConsumeResources();

        // Simulate resource production over time
        // ProduceResources();
        // Debug.log(food);
    }

    // void ConsumeResources()
    // {
    //     // Consume resources based on consumption rates
    //     food -= foodConsumptionRate * Time.deltaTime;
    //     water -= waterConsumptionRate * Time.deltaTime;
    //     energy -= energyConsumptionRate * Time.deltaTime;

    //     // Ensure resources do not go below zero
    //     ClampResources();
    // }

    // void ProduceResources()
    // {
    //     // Produce resources based on production rates
    //     food += foodProductionRate * Time.deltaTime;
    //     water += waterProductionRate * Time.deltaTime;
    //     energy += energyProductionRate * Time.deltaTime;

    //     // Ensure resources do not exceed 100
    //     ClampResources();
    // }

    void ClampResources()
    {
        // Ensure resources stay within the range of 0 to 100
        food = Mathf.Clamp(food, 0, 100);
        water = Mathf.Clamp(water, 0, 100);
        energy = Mathf.Clamp(energy, 0, 100);
    }

    // function to be called when consuming food
    public void ConsumeFood(int amount)
    {
        food -= amount;

        // Ensure food does not go below zero
        ClampResources();
    }

    // Example function to be called when producing water
    public void ConsumeWater(int amount)
    {
        water -= amount;

        // Ensure water does not exceed 100
        ClampResources();
    }

    // function to be called when producingfood
    public void ProduceFood(int amount)
    {
        food += amount;

        // Ensure food does not go below zero
        ClampResources();
    }

    // Example function to be called when producing water
    public void ProduceWater(int amount)
    {
        water += amount;

        // Ensure water does not exceed 100
        ClampResources();
    }
}
