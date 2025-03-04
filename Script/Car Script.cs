using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    [Header("Wheel Collider")]
    public WheelCollider WheelFL;
    public WheelCollider WheelFR;
    public WheelCollider WheelRL;
    public WheelCollider WheelRR;

    [Header("Wheel Transform")]
    public Transform WheelFLTrans;
    public Transform WheelFRTrans;  
    public Transform WheelRLTrans;
    public Transform WheelRRTrans;

    [Header("Car Engine")]
    public float acceleration = 300f;
    public float breakForce = 30000f;
    public float presentBreakForce = 0f;
    public float presentAcceleration = 0f;

}
