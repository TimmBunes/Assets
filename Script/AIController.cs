using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [Header("Car Engine")]
    public float movingSpeed;
    public float turnSpeed = 50f;
    public float breakSpeed = 12f;

    [Header("Destination Var")] 
    public Vector3 destination;
    public bool destinationReached;


    public void Update()
    {
       Drive();
    }

    public void Drive()
    {
        if(transform.position != destination)
        {
            Vector3 destinationDirection = destination - transform.position;
            destinationDirection.y = 0;
            float destinationDistance = destinationDirection.magnitude;

            if(destinationDistance >= breakSpeed)
            {
                destinationReached = false;
                Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
                

                transform.Translate(Vector3.forward * movingSpeed * Time.deltaTime);
            }
        }
        else
        {
            destinationReached = true;
        }

    }

    public void LocateDestination(Vector3 destination)
    {
        this.destination = destination;
        destinationReached = false;
    }

}
