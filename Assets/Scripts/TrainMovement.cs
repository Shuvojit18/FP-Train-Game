using UnityEngine;
//using UnityEngine.UI;

public class TrainMovement : MonoBehaviour
{
    public float speed = 0.0f;
    public float accl = 0.0f;
    public bool signal = false;
    public bool isBraking = true;
    //public Toggle myToggle;
    public float maxSpeed = 20.0f;
    public float throttle;
    public bool delegation = false;
    public AudioSource horn;
    public AudioSource engine;

    void Start()
    {
        //engine = GetComponent<AudioSource>();
    }

    void Update()
    {
        //simple automation, if delegation is on, then whole system is automated, train control only depends on signal
        if (delegation){
            if (signal){
                isBraking = false;  
                throttle = maxSpeed;  
            } 
            else {
                throttle = 0;
                isBraking = true;
            }    
        }
            
        if (isBraking){
            if (speed > 0) speed = speed - accl*2; 
            transform.Translate(Vector3.right * speed * accl);
        } else{
            if (speed < throttle) speed = speed + accl;
            else if (speed > throttle) speed = speed - accl/3;
            // Move the train along the X-axis
            transform.Translate(Vector3.right * speed * accl);
        }
    }

    // Call this method to start moving the train
    public void StartMoving()
    {
        isBraking = false;
    }

    // Call this method to stop the train
    public void StopMoving()
    {
        isBraking = true;
    }

    public void ChangeBrake(){

        isBraking = !isBraking;

    }

    public void ChangeThrottle(float f){
        throttle = maxSpeed * f;
    }
}
