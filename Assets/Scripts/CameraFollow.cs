using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject train; // Assign
    public float offset, targetOffset = 0.01f;
    float smoothTime = 2f; // Approx time to reach the target
    float velocity = 0f; // Current velocity, this value is modified by the function every time you call it

    void LateUpdate(){
        // Follow the train's X position with an offset
        offset = Mathf.SmoothDamp(offset, targetOffset, ref velocity, smoothTime);  //adapted from https://docs.unity3d.com/ScriptReference/Mathf.SmoothDamp.html
        transform.position = new Vector3(train.transform.position.x + offset, transform.position.y, transform.position.z);      
    }
}
