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

    [Header("Car Steering")]
    public float wheelsTorque = 35f;
    private float presentTurnAngle = 0f;



    private void Update()
    {
        MoveCar();
        CarSteering();
        BreakCar();
    }

    private void MoveCar()
    {

        WheelFL.motorTorque = presentAcceleration;
        WheelFR.motorTorque = presentAcceleration;
        WheelRL.motorTorque = presentAcceleration;
        WheelRR.motorTorque = presentAcceleration;

        presentAcceleration = acceleration * Input.GetAxis("Vertical");

    }

    public void CarSteering()
    {
        presentTurnAngle = wheelsTorque * Input.GetAxis("Horizontal");
        WheelFL.steerAngle = presentTurnAngle;
        WheelFR.steerAngle = presentTurnAngle;

        SteeringWheel(WheelFL, WheelFLTrans);
        SteeringWheel(WheelFR, WheelFRTrans);
        SteeringWheel(WheelRL, WheelRLTrans);
        SteeringWheel(WheelRR, WheelRRTrans);
    }

    void SteeringWheel(WheelCollider WC, Transform WT)
    {
        Vector3 pos;    
        Quaternion rot;

        WC.GetWorldPose(out pos, out rot);
        WT.position = pos;
        WT.rotation = rot;
    }

    public void BreakCar()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            presentBreakForce = breakForce;
        }
        else
        {
            presentBreakForce = 0f;
        }
        WheelFL.brakeTorque = presentBreakForce;
        WheelFR.brakeTorque = presentBreakForce;
        WheelRL.brakeTorque = presentBreakForce;
        WheelRR.brakeTorque = presentBreakForce;
    }
}