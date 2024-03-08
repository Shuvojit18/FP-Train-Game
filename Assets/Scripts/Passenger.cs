using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Passenger : MonoBehaviour
{
    public GameObject goal;
    NavMeshAgent agent;

    bool animate;
    private Animator animator;
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        StartCoroutine(ExecuteEverySecond());

    }

    IEnumerator ExecuteEverySecond() {
        while (true) {
            float distance = Mathf.Abs(goal.transform.position.x - transform.position.x);
            //Debug.Log(distance);
            // run
            // Check if the character is nearly stationary by checking the magnitude of the velocity vector
            bool isStationary = agent.velocity.magnitude < 0.1f; 
        if (distance < 30f && distance >= 5f) {
            agent.destination = goal.transform.position; 
            animator.SetBool("isRunning", true); // Start running
            animator.SetBool("isTalking", false); // Ensure not talking
        } else if (distance < 5f && isStationary) {
            animator.SetBool("isRunning", false); // Stop running
            animator.SetBool("isTalking", true); // Start talking
        } else {
            // Ensure both are false if none of the conditions are met
            animator.SetBool("isRunning", false);
            animator.SetBool("isTalking", false);
        }
            yield return new WaitForSeconds(1f); // Wait for one second
        }
    }

    // Update is called once per frame
    // void FixedUpdate()
    // {
    //     // if (Mathf.Abs(goal.transform.position.x - transform.position.x)< 40f){
    //     //         //agent.destination = goal.transform.position; 
    //     //         animator.SetBool("isRunning", true); // run
    //     // } else if (Mathf.Abs(goal.transform.position.x - transform.position.x) < 3f){
    //     //         animator.SetBool("isTalking", true); // talk
    //     // }
    // }
}
