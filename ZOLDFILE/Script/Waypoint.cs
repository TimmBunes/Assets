using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
   [Header("Waypoint Status")]
   public Waypoint previousWaypoint;
    public Waypoint nextWaypoint;

    [Range(0f, 10f)]
    public float WaypointWidth = 1f;

    public Vector3 GetPosition()
    {
        Vector3 minBound = transform.position + transform.right * WaypointWidth / 2f;
        Vector3 maxBound = transform.position - transform.right * WaypointWidth / 2f;

        return Vector3.Lerp(minBound, maxBound, Random.Range(0f, 1f));
    }
}
