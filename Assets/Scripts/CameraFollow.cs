using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject train; // Assign your train GameObject in the inspector
    public float offset = 5.0f; // Adjust this value as needed

    void LateUpdate()
    {
        if (train != null)
        {
            // Follow the train's X position with an offset
            Vector3 newPosition = new Vector3(train.transform.position.x + offset, transform.position.y, transform.position.z);
            transform.position = newPosition;
        }
    }
}
