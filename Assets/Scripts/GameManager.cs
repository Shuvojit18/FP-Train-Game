using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    PassengerCarriage pc;
    TrainMovement tm;
    GameObject pcModel;
    CameraFollow cf;
    CarriageUIManager ui;
    InputHandler input;

    int timer = 0;
    bool doOnce = true;

    

    // Start is called before the first frame update
    void Start()
    {
        pc = FindObjectOfType<PassengerCarriage>();
        pcModel = pc.transform.GetChild(0).gameObject;
        tm = FindObjectOfType<TrainMovement>();
        DontDestroyOnLoad(this.gameObject);
        cf = FindObjectOfType<CameraFollow>();
        ui = FindObjectOfType<CarriageUIManager>();
        input = FindObjectOfType<InputHandler>();
        StartCoroutine(ExecuteEverySecond());
        StartCoroutine(UnlockPassengerCarriage());

    }

    //Using coroutine to save resouces for those function that doesnt require update every frame
    IEnumerator ExecuteEverySecond() {
        while (true) {
            timer++;
            if(timer == 15) Reset();
            yield return new WaitForSeconds(1f); // Wait for one second
        }
    }

    IEnumerator UnlockPassengerCarriage(){
        yield return new WaitUntil(() => PassengerCarriageUnlockCondition() && input.playerDecision); // adapted from unity doc - "https://docs.unity3d.com/ScriptReference/WaitUntil.html"
        
        
        pc.unlocked = true;
        Debug.Log("Passenger Carriage Unlocked!");
        pcModel.SetActive(true);
        cf.targetOffset = -5f;
        tm.accl = tm.accl - 0.005f;
        ui.HideDecisionPanel();
        //increase passenger morale
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
                return true;
        } else return false;    // unlock passenger carriage 
    }

    //Resets some logics so user can interact again
    void Reset(){
        //ui.HideActionPanel();
        ui.HideInteractionPanel();
        //ui.HideDecisionPanel();
        timer = 0;
        doOnce = true;
    } 
}
