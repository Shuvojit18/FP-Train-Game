using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    Slider progressBar;
    public GameObject[] stations; // using Array to store the station locations
    public GameObject train; //  current progress
    GameObject approachingStation;
    private int currentStationIndex = 0;
    float maxValue;
    float currentValue;
    private float lastStationPosition = 0f; // Store the position of the last station

    //private TrainMovement tm;

    void Start()
    {
        progressBar = GetComponent<Slider>();
        //approachingStation = stations[currentStationIndex];
        //tm = FindObjectOfType<TrainMovement>();
    }

    void Update()
    {
        if (currentStationIndex < stations.Length){
            approachingStation = stations[currentStationIndex];
            maxValue = Mathf.Abs(approachingStation.transform.position.x - lastStationPosition); //returns absolute value
            currentValue = Mathf.Clamp(train.transform.position.x - lastStationPosition, 0, maxValue); //clamps those values

            progressBar.value = currentValue / maxValue;

            // Check if train has reached or surpassed the current station
            if (train.transform.position.x >= approachingStation.transform.position.x)
            {
                lastStationPosition = approachingStation.transform.position.x;
                //tm.signal = false;
                // Move to the next station in the array
                currentStationIndex++;
                
                if (currentStationIndex >= stations.Length)
                {
                    Debug.Log("Reached the end of station");
                }
            }
        }
        
        
    }
}
