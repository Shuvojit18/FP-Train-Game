using UnityEngine;

public class PathMovement : MonoBehaviour
{
    public Transform[] waypoints; // Assign in Inspector
    public float speed = 2f;
    public bool reverseAtEnds = true; // Determines if the path reverses at ends
    public bool allowMovement = true; // New flag to control movement

    private int waypointIndex = 0;
    private bool movingRight = true;

    void FixedUpdate()
    {
        if (allowMovement) MoveAlongPath();

    }

    void MoveAlongPath()
    {
        if (waypointIndex < waypoints.Length && waypointIndex >= 0)
        {
            Transform targetWaypoint = waypoints[waypointIndex];
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

            if (transform.position == targetWaypoint.position)
            {
                if (movingRight)
                {
                    if (waypointIndex == waypoints.Length - 1) // If at the last waypoint
                    {
                        if (reverseAtEnds)
                        {
                            waypointIndex--;
                            movingRight = false;
                        }
                        else
                        {
                            // Disable further movement
                            allowMovement = false;
                        }
                    }
                    else
                    {
                        waypointIndex++;
                    }
                }
                else // Moving left
                {
                    if (waypointIndex == 0) // If at the first waypoint
                    {
                        if (reverseAtEnds)
                        {
                            waypointIndex++;
                            movingRight = true;
                        }
                        else
                        {
                            // Disable further movement
                            allowMovement = false;
                        }
                    }
                    else
                    {
                        waypointIndex--;
                    }
                }
            }
        }
    }
}
