using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICarWaypoint : MonoBehaviour
{
   [Header("Ai Car")]
   public AIController aiController;
   public Waypoint currentWaypoint;

   public void Awake()
   {
      aiController = GetComponent<AIController>();
   }

   private void Start()
   {
      aiController.LocateDestination(currentWaypoint.GetPosition());
   }

   public void Update()
   {
      if(aiController.destinationReached)
      {
         currentWaypoint = currentWaypoint.nextWaypoint;
         aiController.LocateDestination(currentWaypoint.GetPosition());
      }
   }
}