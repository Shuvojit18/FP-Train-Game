using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    EngineCarriage ec;
    PassengerCarriage pc;
    StorageCarriage sc;
    TrainMovement tm;
    GameObject pcModel;
    GameObject scModel;
    CameraFollow cf;
    CarriageUIManager ui;
    InputHandler input;
    public GameObject passenger;
    int timer = 0;
    bool doOnce = true;

    //public float socket;
    

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        ec = FindObjectOfType<EngineCarriage>();
        pc = FindObjectOfType<PassengerCarriage>();
        sc = FindObjectOfType<StorageCarriage>();
        
        pcModel = pc.transform.GetChild(0).gameObject;
        scModel = sc.transform.GetChild(0).gameObject;
        
        tm = FindObjectOfType<TrainMovement>();
        cf = FindObjectOfType<CameraFollow>();
        ui = FindObjectOfType<CarriageUIManager>();
        input = FindObjectOfType<InputHandler>();
        
        StartCoroutine(ExecuteEverySecond());
        StartCoroutine(UnlockPassengerCarriage());
        StartCoroutine(PickupPassenger());
    }

    //Using coroutine to save resouces for those function that doesnt require update every frame
    IEnumerator ExecuteEverySecond() {
        while (true) {
            timer++;
            if(timer == 15) Reset();
            yield return new WaitForSeconds(1f); // Wait for one second
        }
    }

    // Passenger carriage unlock event 
    IEnumerator UnlockPassengerCarriage(){
        yield return new WaitUntil(() => PassengerCarriageUnlockCondition() && input.playerDecision); // adapted from unity doc - "https://docs.unity3d.com/ScriptReference/WaitUntil.html"
        
        pc.unlocked = true;
        Debug.Log("Passenger Carriage Unlocked!");
        pcModel.SetActive(true);
        cf.targetOffset = -2.5f;
        tm.accl = tm.accl - 0.007f;
        ui.HideDecisionPanel();
        pc.PassengerMorale = pc.PassengerMorale + pc.PassengerMorale/3; //increase passenger morale
        Debug.Log(pc.PassengerMorale);
        //socket = socket + 5f;
    } 

    //check if player can unclock carriage
    bool PassengerCarriageUnlockCondition(){
        if (tm.isNear1stStation && tm.isStopping && !pc.unlocked){
                if(doOnce){
                    string mssg = "There is a passenger carriage on a loop line. Attaching it to our train will greatly boost passenger morale but train accelaration will take a hit. would you like to attach it to the train? ";
                    ui.ShowDecisionPanel(mssg);
                    doOnce = false;
                }
                return true;    // unlock passenger carriage
        } else return false;     
    }

       //pickup Passenger 
    IEnumerator PickupPassenger(){
        yield return new WaitUntil(() => CanPickupPassenger() && input.playerDecision); // adapted from unity doc - "https://docs.unity3d.com/ScriptReference/WaitUntil.html"
        
        Debug.Log("Passenger Picked up!");
        passenger.SetActive(false);
        ui.HideDecisionPanel();
        pc.PassengerMorale = pc.PassengerMorale + pc.PassengerMorale/3; //increase passenger morale
        Debug.Log(pc.PassengerMorale);
        pc.PassengerCount++;
    }

    //check if player can pickup passenger
    bool CanPickupPassenger(){
        if (tm.isNear2ndStation && tm.isStopping){
            if(doOnce){
                string message = "Pls take me with you, i am wounded and bad people are after me !!";
                ui.ShowDecisionPanel(message);
                doOnce = false;
                return true;    // pickup a passenger 
            }return true;
        }else return false;   
    }

    //Resets some logics so user can interact again
    void Reset(){
        ui.HideInteractionPanel();
        timer = 0;
        doOnce = true;
        input.playerDecision = false;
    } 
}



    //FixedUpdate is called 50 times a sec
    // void FixedUpdate(){  
    // }

    // IEnumerator UnlockStorageCarriage(){
    //     yield return new WaitUntil(() => StorageCarriageUnlockCondition() && input.playerDecision); // adapted from unity doc - "https://docs.unity3d.com/ScriptReference/WaitUntil.html"
    //     sc.unlocked = true;
    //     Debug.Log("Storage Carriage Unlocked!");
    //     scModel.SetActive(true);
    //     cf.targetOffset = -5f;
    //     tm.accl = tm.accl - 0.005f;
    //     ui.HideDecisionPanel();
    //     pc.PassengerMorale = pc.PassengerMorale + pc.PassengerMorale/4; //increase passenger morale
    //     Debug.Log(pc.PassengerMorale);
    //     //socket = socket - 5f;
    // } 
 // bool StorageCarriageUnlockCondition(){
    //     if (tm.isNear2ndStation && tm.isStopping && !sc.unlocked){
    //             if(doOnce){
    //                 ui.ShowDecisionPanel();
    //                 doOnce = false;
    //             }
    //             return true;    // unlock Resource carriage 
    //     } else return false;    
    // }