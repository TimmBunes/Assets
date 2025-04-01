using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[InitializeOnLoad]
public class WaypointEditor
{
    [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected | GizmoType.Pickable)]
    public static void ONDrawSceneGizmos(Waypoint waypoint, GizmoType gizmoType)
    {
        if ((gizmoType & GizmoType.Selected) != 0)
        {
            Gizmos.color = Color.blue;
        
        }
        else 
        {
            Gizmos.color = Color.blue * 0.5f;
            
        }
        
        Gizmos.DrawSphere(waypoint.transform.position, 0.5f);
        Gizmos.color = Color.white;
        Gizmos.DrawLine(waypoint.transform.position + (waypoint.transform.right * waypoint.WaypointWidth / 2f), waypoint.transform.position - (waypoint.transform.right * waypoint.WaypointWidth / 2f));

        if (waypoint.previousWaypoint != null)
        {
            Gizmos.color = Color.red;
            Vector3 offset = waypoint.transform.right * waypoint.WaypointWidth / 2f;
            Vector3 OffsetTo = waypoint.previousWaypoint.transform.right * waypoint.previousWaypoint.WaypointWidth / 2f;

            Gizmos.DrawLine(waypoint.transform.position + offset, waypoint.previousWaypoint.transform.position + OffsetTo);
        }

        if(waypoint.nextWaypoint != null)
        {
            Gizmos.color = Color.green;
            Vector3 offset = waypoint.transform.right * -waypoint.WaypointWidth / 2f;
            Vector3 offsetTO = waypoint.previousWaypoint.transform.right * -waypoint.previousWaypoint.WaypointWidth / 2f;

            Gizmos.DrawLine(waypoint.transform.position + offset, waypoint.previousWaypoint.transform.position + offsetTO);
        }
    }
}
