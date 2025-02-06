using UnityEngine;

public class Wheels : MonoBehaviour
{
    [SerializeField] private Vehicle weeldVehicle; 
    [SerializeField] private GameObject[] forwardWheels;
    [SerializeField] private GameObject[] backwardWheels; 

    private float rotationAngle; 

    void FixedUpdate()
    {
        if (weeldVehicle == null)
        {
            Debug.LogWarning("Vehicle is not assigned!");
            return;
        }

        float verticalInput = weeldVehicle.VerticalMovement;
        float horizontalInput = weeldVehicle.HorizontalMovement;

        RotateWheels(verticalInput);

        SteerWheels(horizontalInput);
    }

    private void RotateWheels(float verticalInput)
    {
        rotationAngle += verticalInput * weeldVehicle.Speed * 10 * Time.deltaTime;

        foreach (GameObject wheel in forwardWheels)
        {
            wheel.transform.localRotation = Quaternion.Euler(rotationAngle, 0, 0);
        }
        foreach (GameObject wheel in backwardWheels)
        {
            wheel.transform.localRotation = Quaternion.Euler(rotationAngle, 0 + weeldVehicle.steerKostyl, 0);
        }
    }

    private void SteerWheels(float horizontalInput)
    {
        float maxSteerAngle = weeldVehicle.turnAngle;
        float steerAngle = horizontalInput * maxSteerAngle;

        foreach (GameObject wheel in forwardWheels)
        {
            Vector3 localEulerAngles = wheel.transform.localEulerAngles;
            wheel.transform.localRotation = Quaternion.Euler(localEulerAngles.x, steerAngle + weeldVehicle.steerKostyl, localEulerAngles.z);
        }
    }
}
