using UnityEngine;

//child class of train carriage
public class PassengerCarriage : TrainCarriage
{
    public int PassengerCount { get; private set; }
    public int PassengerMorale { get; set; }
    public int PassengerHealth { get; private set; }
    public bool unlocked = false;

    EngineCarriage ec;
    private ResourceManager resource;
    GameManager gm;
    bool doOnce = true;
    bool pull = false;

    //for lerp calculation
    // float startValue, endValue, timeElapsed = 0f;
    // float duration = 3f; // Duration of the transition in seconds
    //if we require more than 1 passenger car this may come in handy
    // public PassengerCarriage(int initialPassengers)
    // {
    //     PassengerCount = initialPassengers;
    //     PassengerMorale = 100; // Start with full morale
    //     PassengerHealth = 100; // Start with full health
    // }

    void Start(){
        CarriageType = "Passenger";
        PassengerCount = 10; // passenger count, can be set differently
        PassengerMorale = 25; // Start with half morale
        PassengerHealth = 25; // Start with half health

        resource = FindObjectOfType<ResourceManager>();
        gm = FindObjectOfType<GameManager>();
        ec = FindObjectOfType<EngineCarriage>();
        //this.SetVisibility = false;

    }

    void FixedUpdate(){
        //if(ec.transform.position.x - transform.position.x > 20) transform.Translate(Vector3.right * 0.1f);
        if(unlocked && pull){
            if(ec.transform.position.x - transform.position.x < 5.5f) Debug.Log("Collision !!!! Game over !!");      
            
            transform.Translate(Vector3.right * 0.015f);
        }
    }

    public override void Interact(){
        base.Interact();
        if(PassengerHealth <= 0){
            PassengerCount = 0;
            Debug.Log("All passenger dead, game over");
        }

        if (PassengerMorale <= 0){
            PassengerCount--;
            Debug.Log("Passengers are depressed, 1 person died");
        }
        CarriageStatus = PassengerCount + " Passengers. " + " Health - " + PassengerHealth  + " Morale - " + PassengerMorale;

    }

     // distribute meal to passengers
    public void DistributeMeal(){
        if(resource.getFood() > 0 && resource.getWater() > 0){
            PassengerHealth = PassengerHealth + PassengerCount/2;
            PassengerMorale = PassengerMorale + PassengerCount/3;
            Clamp();
            resource.ConsumeFood(PassengerCount);
            resource.ConsumeWater(PassengerCount);
        } else {
            //Debug.Log("Not enough food");
        }   
    }

    // distribute soup to passengers
    public void DistributeSoup(){
        if(resource.getFood() + resource.getWater() > 0){
            PassengerHealth++;
            PassengerHealth++;
            PassengerMorale--;
            Clamp();
            resource.ConsumeFood(PassengerCount/3);
            resource.ConsumeWater(PassengerCount/2);
        }
    }

    void Clamp(){
       // PassengerCount = Mathf.Clamp(PassengerCount, 0, 10);
        PassengerHealth = Mathf.Clamp(PassengerHealth, 0, 100);
        PassengerMorale = Mathf.Clamp(PassengerMorale, 0, 100);
        Debug.Log(PassengerHealth + "-health.morale-" + PassengerMorale);
    }

    public void pullCarriage(){
        pull = !pull;
    }


}
