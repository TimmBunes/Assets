using UnityEngine;

public class Car : MonoBehaviour
{
    [Header("Wheels Collider")]
    public WheelCollider frontRightWheelCollider;
    public WheelCollider frontLeftWheelCollider;
    public WheelCollider rearRightWheelCollider;
    public WheelCollider rearLeftWheelCollider;
    [Header("Wheels Transform")]
    public Transform frontRightWheelTransform;
    public Transform frontLeftWheelTransform;
    public Transform rearRightWheelTransform;
    public Transform rearLeftWheelTransform;

    [Header("Car Engine")]
    public float acceleration = 50000f; // Increased from 5000f
    public float breakForce = 3000f;
    public float presentbreakForce = 0f;
    public float presentAcceleration = 0f;

    [Header("Car Steering")]
    public float wheelTorque = 35f;
    private float steeringAngle = 35f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = 500f; // Reduced mass
        rb.linearDamping = 0.1f; // Reduce drag to minimize resistance
    }

    private void Update()
    {
        MoveCar();
        CarSteering();
    }

    private void MoveCar()
    {
        float verticalInput = Input.GetAxis("Vertical");
        presentAcceleration = acceleration * verticalInput;

        if (verticalInput == 0)
        {
            presentbreakForce = breakForce;
        }
        else
        {
            presentbreakForce = 0f;
        }

        frontLeftWheelCollider.motorTorque = presentAcceleration;
        frontRightWheelCollider.motorTorque = presentAcceleration;
        rearLeftWheelCollider.motorTorque = presentAcceleration;    
        rearRightWheelCollider.motorTorque = presentAcceleration;

        frontLeftWheelCollider.brakeTorque = presentbreakForce;
        frontRightWheelCollider.brakeTorque = presentbreakForce;
        rearLeftWheelCollider.brakeTorque = presentbreakForce;
        rearRightWheelCollider.brakeTorque = presentbreakForce;
    }

    private void CarSteering()
    {
        steeringAngle = wheelTorque * Input.GetAxis("Horizontal");
        frontLeftWheelCollider.steerAngle = steeringAngle;
        frontRightWheelCollider.steerAngle = steeringAngle;
    }
}