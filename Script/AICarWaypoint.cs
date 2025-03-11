using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICarWaypoint : MonoBehaviour
{
   [Header("Component Car")]
   public AIController aiController;
   public Waypoint currentWaypoint;

   public void Awake()
   {
      aiController = GetComponent<AIController>();
   }

   private void Start()
   {
      aiController.LocateDestinations(currentWaypoint.GetPosition());
   }

   public void Update()
   {
      if(aiController.destinationReached)
      {
         currentWaypoint = currentWaypoint.nextWaypoint;
         aiController.LocateDestinations(currentWaypoint.GetPosition());
      }
   }
}
