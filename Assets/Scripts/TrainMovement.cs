using UnityEngine;

public class TrainMovement : MonoBehaviour
{
    public float speed = 0.0f;
    public float accl = 0.0f;
    public bool isMoving = true;
    public bool isBraking = true;

    void Update()
    {
        if (isMoving && !isBraking)
        {
            if (speed < 10) speed = speed + accl;
            // Move the train along the X-axis
            transform.Translate(Vector3.right * speed * accl);
        }

        if (isBraking){
            if (speed > 0) speed = speed - accl; 
            transform.Translate(Vector3.right * speed * accl);
        }
    }

    // Call this method to start moving the train
    public void StartMoving()
    {
        isMoving = true;
    }

    // Call this method to stop the train
    public void StopMoving()
    {
        isMoving = false;
    }
}
