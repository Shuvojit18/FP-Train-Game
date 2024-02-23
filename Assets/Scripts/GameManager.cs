using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
       // StartCoroutine(ExecuteEverySecond());
        StartCoroutine(UnlockPassengerCarriage());
    }

    //Using coroutine to save resouces for those function that doesnt require update every frame
    // IEnumerator ExecuteEverySecond() {
    //     while (true) {

        
    //         yield return new WaitForSeconds(1f); // Wait for one second
    //     }
    // }

    IEnumerator UnlockPassengerCarriage(){
        yield return new WaitUntil(() => true); // adapted from unity doc - "https://docs.unity3d.com/ScriptReference/WaitUntil.html"
        // Code to unlock the ability goes here
        Debug.Log("Passenger Carriage Unlocked!");
    }


    // FixedUpdate is called 50 times a sec
    // void FixedUpdate()
    // {
        
    // }
}
