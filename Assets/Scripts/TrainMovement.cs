using UnityEngine;

public class TrainMovement : MonoBehaviour
{
    public float speed = 1.0f;
    public bool isMoving = true;

    void Update()
    {
        if (isMoving)
        {
            if (speed < 6) speed = speed + Time.deltaTime - 0.0125f;
            // Move the train along the X-axis
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    // Call this method to start moving the train
    public void StartMoving()
    {
        isMoving = true;
    }

    // Call this method to stop the train
    public void StopMoving()
    {
        isMoving = false;
    }
}
