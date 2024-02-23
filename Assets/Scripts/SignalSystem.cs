using UnityEngine;
using System.Collections;

public class SignalSystem : MonoBehaviour
{
    public bool signal = false;
    public float intervalSeconds = 1f; // Time interval in seconds

    private TrainMovement tm;

    void Start()
    {
        tm = FindObjectOfType<TrainMovement>();
        // InvokeRepeating("ToggleSignal", 5f, intervalSeconds); 
        StartCoroutine(Delay()); // Start the coroutine
    }
    

    IEnumerator Delay() {
        while (true) {
            yield return new WaitForSeconds(intervalSeconds);
            ToggleSignal();    
            Debug.Log("fire");
        }
    }
    private void ToggleSignal()
    {
        if (Random.value > 0.5f) signal = true;
        else signal = false;
        tm.signal = signal;
        Debug.Log(signal);
    }
}
