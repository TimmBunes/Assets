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
    public float acceleration = 1000f; // Increased acceleration value
    public float breakForce = 30000f;
    public float presentBreakForce = 0f;
    public float presentAcceleration = 0f;

    private void Update()
    {
        MoveCar();
    }

    private void MoveCar()
    {
        presentAcceleration = acceleration * Input.GetAxis("Vertical");

        WheelFL.motorTorque = presentAcceleration;
        WheelFR.motorTorque = presentAcceleration;
        WheelRL.motorTorque = presentAcceleration;
        WheelRR.motorTorque = presentAcceleration;

        WheelFLTrans.Rotate(WheelFL.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        WheelFRTrans.Rotate(WheelFR.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        WheelRLTrans.Rotate(WheelRL.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        WheelRRTrans.Rotate(WheelRR.rpm / 60 * 360 * Time.deltaTime, 0, 0);
    }
}