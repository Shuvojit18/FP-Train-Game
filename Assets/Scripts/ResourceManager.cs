using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    // Resource variables
    private int food = 100;
    private int water = 100;
    private int fuel = 100;

    public EngineCarriage engine;
    // Resource consumption rates
    // private int foodConsumptionRate = 10;
    // private int waterConsumptionRate = 10;
    // private int fuelConsumptionRate = 10;

    // Resource production rates
    // private int foodProductionRate = 3;
    // private int waterProductionRate = 5;
    // private int fuelProductionRate = 8;

    // public float delay = 1f;
    // float timer;

    void Start(){
        //Invoke("ConsumeResources", 1);
        engine = FindObjectOfType<EngineCarriage>();

        InvokeRepeating("ConsumeFuel", 0, 1.0f);


    }
    // void Update()
    // {
        // timer += Time.deltaTime;
        // if (timer > delay)
        // {
        // //Simulate resource consumption over time
        // ConsumeResources();
        // timer -= delay;

        // }
        // Simulate resource production over time
        // ProduceResources();
        // Debug.log(food);
    //}

    // void ConsumeResources()
    // {
    //     // Consume resources based on consumption rates
    //     food -= foodConsumptionRate;
    //     water -= waterConsumptionRate;
    //     //fuel -= fuelConsumptionRate;

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
        fuel = Mathf.Clamp(fuel, 0, 1000);
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

    public void ConsumeFuel()
    {
        if(engine.isRunning && fuel>0){
            fuel--;
        }
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

    public int getFood(){
        return food;
       // return water;
    }

    public int getWater(){
        return water;
       // return water;
    }

    public int getfuel(){
        return fuel;
       // return fuel;
    }
}
