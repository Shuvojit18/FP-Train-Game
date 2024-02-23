using UnityEngine;
using System.Collections;


public class TrainMovement : MonoBehaviour
{
    public float speed = 0.0f;
    public float accl = 0.01f;
    public bool signal = false;
    public bool isBraking = true;
    public float maxSpeed = 36.0f;
    public float throttle;
    public bool delegation = false;
    public bool coupling = true;
    public bool isStopping = false;

    private float stopThreshold = 1f; // Speed below which the train is considered to be stopping
    private bool isNearStation = true;

    
    
    void Start(){        
        StartCoroutine(ExecuteEverySecond());
    }

    //using coroutine to save resouces for those function that doesnt require update every frame
    IEnumerator ExecuteEverySecond() {
        while (true) {
            
            //Debug.Log("Executed once per second");
            if (speed <= stopThreshold){
                isStopping = true;
                CheckIfStoppedCorrectly();
            } else {
                isStopping = false;
            }

            //simple automation, if delegation is on, then whole system is automated, train control only depends on signal

            if (delegation){
                if (signal){
                    StartMoving();
                } 
                else {
                    StopMoving();
                }    
            }

            yield return new WaitForSeconds(1f); // Wait for one second
        }
    }


    void FixedUpdate(){
        if (isBraking){
            if (speed > 0) speed = speed - accl*2; 
            if(coupling) transform.parent.Translate(Vector3.right * speed * accl);
            else transform.Translate(Vector3.right * speed * accl);
        } else{
            if (speed < throttle) speed = speed + accl;
            else if (speed > throttle) speed = speed - accl/3;
            // Move the train along the X-axis
            if(coupling) transform.parent.Translate(Vector3.right * speed * accl);
            else transform.Translate(Vector3.right * speed * accl);
        }
    }

    // Call this to start moving the train
    public void StartMoving()
    {
        isBraking = false;
        throttle = maxSpeed;
    }

    // Call this method to stop the train
    public void StopMoving()
    {
        isBraking = true;
        throttle = 0;
    }

    public void ChangeBrake(){

        isBraking = !isBraking;

    }

    public void ChangeThrottle(float f){
        throttle = maxSpeed * f;
    }

    void OnTriggerEnter(Collider other)
    {
        // if (other.CompareTag("station"))
        // {
        //     isNearStation = true;
        // }

        // var isNearStartStation = other.CompareTag("Start Station") ? true : false;
        // var isNear1stStation = other.CompareTag("1st Station") ? true : false;
        // var isNear2ndStation = other.CompareTag("2nd Station") ? true : false;
        // var isNear3rdStation = other.CompareTag("3rd Station") ? true : false;

        // //if(isNear1stStation || isNear2ndStation || isNear3rdStation) isNearStation = true;

        // isNearStation = (isNearStartStation || isNear1stStation || isNear2ndStation || isNear3rdStation) ? true : false;
       
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("station"))
        {
            isNearStation = false;
        }
    }

    void CheckIfStoppedCorrectly()
    {
        if (!isNearStation) {
            // Logic for incorrect stopping
            Debug.Log("game over");
        }
    }

    void Reverse(){

    }
}
