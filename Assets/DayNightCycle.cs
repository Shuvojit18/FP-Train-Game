using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float cycleSpeed = 1f; // Speed of the day/night cycle
    public Camera mainCamera; // Assign main camera

    // Define the day and night colors
    public Color dayColor = new Color(1f, 0.9f, 0.7f); // Warm yellowish
    public Color nightColor = new Color(0.1f, 0.1f, 0.5f); // Dark 

    private void Update()
    {
        // Rotate the light around the X axis at a constant speed
        transform.Rotate(cycleSpeed * Time.deltaTime, 0, 0, Space.World);

        // Calculate the bg color based on the light's X rotation
        // float t = Mathf.Cos((transform.eulerAngles.x + 90) * Mathf.Deg2Rad) * 0.5f + 0.5f;
        // mainCamera.backgroundColor = Color.Lerp(nightColor, dayColor, t);
    }
}
