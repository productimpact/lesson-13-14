using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private GameObject controllCanvas;

    float verticalInput = 0f;
    float horizontalInput = 0f;

    public WheelCollider frontLeftWheel;
    public WheelCollider frontRightWheel;
    public WheelCollider rearLeftWheel;
    public WheelCollider rearRightWheel;

    public Transform frontLeftWheelModel;
    public Transform frontRightWheelModel;
    public Transform rearLeftWheelModel;
    public Transform rearRightWheelModel;

    public float motorForce = 1000f;
    public float maxSteerAngle = 30f;

    private bool movingForward;
    private bool movingBackward;
    private bool turningLeft;
    private bool turningRight;

    private void Start()
    {
        if (!Application.isMobilePlatform)
        {
            controllCanvas.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (!Application.isMobilePlatform)
        {
            verticalInput = Input.GetAxis("Vertical"); 
            horizontalInput = Input.GetAxis("Horizontal");
        }

        float motorTorque = verticalInput * motorForce;

        frontLeftWheel.motorTorque = motorTorque;
        frontRightWheel.motorTorque = motorTorque;

        float steerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheel.steerAngle = steerAngle;
        frontRightWheel.steerAngle = steerAngle;

        UpdateWheelAnimation(frontLeftWheel, frontLeftWheelModel);
        UpdateWheelAnimation(frontRightWheel, frontRightWheelModel);
        UpdateWheelAnimation(rearLeftWheel, rearLeftWheelModel);
        UpdateWheelAnimation(rearRightWheel, rearRightWheelModel);
    }

    private void UpdateWheelAnimation(WheelCollider wheelCollider, Transform wheelModel)
    {
        Vector3 position;
        Quaternion rotation;
        wheelCollider.GetWorldPose(out position, out rotation);

        wheelModel.position = position;
        wheelModel.rotation = rotation;
    }

    public void MoveForward()
    {
        verticalInput += .1f;
    }

    public void MoveBackward()
    {
        verticalInput = -1f;
    }

    public void TurnLeft()
    {
        horizontalInput = -1f;
    }

    public void TurnRight()
    {
        horizontalInput = 1f;
    }

    public void StopMoving()
    {
        verticalInput = 0f;
        horizontalInput = 0f;
    }
}
