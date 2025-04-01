using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
    public float breakForce = 60000f;
    public float presentBreakForce = 0f;
    public float presentAcceleration = 0f;

    [Header("Car Steering")]
    public float wheelsTorque = 35f;
    private float presentTurnAngle = 0f;

    [Header("UI Elements")]
    public RawImage brakeButton;

    private bool isBraking = false;

    private void Start()
    {
        // Add event listeners to the brake button
        EventTrigger trigger = brakeButton.gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry pressEntry = new EventTrigger.Entry();
        pressEntry.eventID = EventTriggerType.PointerDown;
        pressEntry.callback.AddListener((data) => { StartBraking(); });
        trigger.triggers.Add(pressEntry);

        EventTrigger.Entry releaseEntry = new EventTrigger.Entry();
        releaseEntry.eventID = EventTriggerType.PointerUp;
        releaseEntry.callback.AddListener((data) => { StopBraking(); });
        trigger.triggers.Add(releaseEntry);
    }

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

        presentAcceleration = acceleration * SimpleInput.GetAxis("Vertical");
    }

    public void CarSteering()
    {
        presentTurnAngle = wheelsTorque * SimpleInput.GetAxis("Horizontal");
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
        if (isBraking || Input.GetKey(KeyCode.Space))
        {
            presentBreakForce = breakForce;
            presentAcceleration = 0f;
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

    public void StartBraking()
    {
        isBraking = true;
    }

    public void StopBraking()
    {
        isBraking = false;
    }
}