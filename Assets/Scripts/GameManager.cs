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

    int timer = 0;
    bool doOnce = true;

    public float socket;
    

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
        StartCoroutine(UnlockStorageCarriage());

        //socket = ec.transform.position.x;
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
        cf.targetOffset = -5f;
        tm.accl = tm.accl - 0.005f;
        ui.HideDecisionPanel();
        pc.PassengerMorale = pc.PassengerMorale + pc.PassengerMorale/3; //increase passenger morale
        Debug.Log(pc.PassengerMorale);
        //socket = socket + 5f;
    } 

    IEnumerator UnlockStorageCarriage(){
        yield return new WaitUntil(() => StorageCarriageUnlockCondition() && input.playerDecision); // adapted from unity doc - "https://docs.unity3d.com/ScriptReference/WaitUntil.html"
        sc.unlocked = true;
        Debug.Log("Storage Carriage Unlocked!");
        scModel.SetActive(true);
        cf.targetOffset = -5f;
        tm.accl = tm.accl - 0.005f;
        ui.HideDecisionPanel();
        pc.PassengerMorale = pc.PassengerMorale + pc.PassengerMorale/4; //increase passenger morale
        Debug.Log(pc.PassengerMorale);
        //socket = socket - 5f;
    } 


    //FixedUpdate is called 50 times a sec
    // void FixedUpdate()
    // {
        
        
    // }

    bool PassengerCarriageUnlockCondition(){
        if (tm.isNear1stStation && tm.isStopping && !pc.unlocked){
                if(doOnce){
                    ui.ShowDecisionPanel();
                    doOnce = false;
                }
                return true;    // unlock passenger carriage
        } else return false;     
    }

    bool StorageCarriageUnlockCondition(){
        if (tm.isNear2ndStation && tm.isStopping && !sc.unlocked){
                if(doOnce){
                    ui.ShowDecisionPanel();
                    doOnce = false;
                }
                return true;    // unlock Resource carriage 
        } else return false;    
    }

    //Resets some logics so user can interact again
    void Reset(){
        ui.HideInteractionPanel();
        timer = 0;
        doOnce = true;
        input.playerDecision = false;
    } 
}
