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
    //public AudioSource horn;
    //public AudioSource engine;

    public bool isStopping = false;
    private float stopThreshold = 1f; // Speed below which the train is considered to be stopping
    private bool isNearStation = true;

    public bool coupling = true;
    
    void Start()
    {
        // GameObject self = this.GameObject;
        // Transform trainTransform = self.transform.parent.parent;

        
        //engine = GetComponent<AudioSource>();
       // Debug.Log(train);

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
            if(coupling) transform.parent.Translate(Vector3.right * speed * accl);
            else transform.Translate(Vector3.right * speed * accl);
        } else{
            if (speed < throttle) speed = speed + accl;
            else if (speed > throttle) speed = speed - accl/3;
            // Move the train along the X-axis
            if(coupling) transform.parent.Translate(Vector3.right * speed * accl);
            else transform.Translate(Vector3.right * speed * accl);
        }

        if (speed <= stopThreshold){
            isStopping = true;
            CheckIfStoppedCorrectly();
        } else {
            isStopping = false;
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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("station"))
        {
            isNearStation = true;
        }
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
