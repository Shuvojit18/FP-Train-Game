using UnityEngine;

public class SignalSystem : MonoBehaviour
{
    public bool signal = false;
    public float intervalSeconds = 100f; // Time interval in seconds

    private TrainMovement tm;

    void Start()
    {
        tm = FindObjectOfType<TrainMovement>();
        InvokeRepeating("ToggleBool", 5f, intervalSeconds); // Start immediately, repeat every intervalSeconds
    }

    private void ToggleBool()
    {
        if (Random.value > 0.5f) signal = true;
        else signal = false;
        
        tm.signal = signal;
        Debug.Log(signal);
    }
}
