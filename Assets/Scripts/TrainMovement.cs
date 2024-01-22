using UnityEngine;
//using UnityEngine.UI;

public class TrainMovement : MonoBehaviour
{
    public float speed = 0.0f;
    public float accl = 0.0f;
    //public bool canMove = true;
    public bool isBraking = true;
    //public Toggle myToggle;
    float maxSpeed = 20.0f;
    public float throttle;

    void Update()
    {
        // //isBraking = myToggle.isOn;
        // if (!isBraking)
        // {
            
        // }

        if (isBraking && throttle < 10){
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

    public void ChangeMaxSpeed(float f){
        throttle = maxSpeed * f;
    }
}
