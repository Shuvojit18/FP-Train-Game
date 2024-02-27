using UnityEngine;
using System.Collections;


public class TrainMovement : MonoBehaviour
{
    public float speed, accl, maxSpeed, throttle = 0.0f; 
    public bool signal, delegation = false;
    public bool isBraking, coupling, isStopping = true;
    public bool isNearStation, isNear1stStation, isNear2ndStation, isNear3rdStation = false;


    private float stopThreshold = 1f; // Speed below which the train is considered to be stopping

    
    
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

    void OnTriggerEnter(Collider other){        
        if (other.CompareTag("1st Station"))isNear1stStation = isNearStation = true;
        if (other.CompareTag("2nd Station")) isNear2ndStation = isNearStation = true;
        if (other.CompareTag("3rd Station"))isNear3rdStation = isNearStation = true;
        
        // var isNearStartStation = other.CompareTag("Start Station") ? true : false;
        //isNear1stStation = other.CompareTag("1st Station") ? true : false;
        // var isNear2ndStation = other.CompareTag("2nd Station") ? true : false;
        // var isNear3rdStation = other.CompareTag("3rd Station") ? true : false;

        // //if(isNear1stStation || isNear2ndStation || isNear3rdStation) isNearStation = true;

        // isNearStation = (isNearStartStation || isNear1stStation || isNear2ndStation || isNear3rdStation) ? true : false;
       
    }

    void OnTriggerExit(Collider other){
        if(other.CompareTag("1st Station"))isNear1stStation = isNearStation = false;
        if(other.CompareTag("2nd Station"))isNear2ndStation = isNearStation = false;
        if(other.CompareTag("3rd Station"))isNear3rdStation = isNearStation = false;
        //isNear1stStation = false;
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

    public void ChangeCoupling(){
        coupling = !coupling;
    }
}
