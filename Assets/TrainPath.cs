using System.Collections.Generic;
using UnityEngine;

public class TrainPath : MonoBehaviour
{
    public List<Transform> waypoints;
    public float speed = 5f;
    private int currentWaypointIndex = 0;

    void Update()
    {
        if (waypoints.Count == 0) return;

        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector3 direction = targetWaypoint.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Count)
            {
                currentWaypointIndex = 0; // ∑Á«¡
            }
        }
        else
        {
            transform.Translate(direction.normalized * distanceThisFrame, Space.World);
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed*0.5f);
        }

    }
}