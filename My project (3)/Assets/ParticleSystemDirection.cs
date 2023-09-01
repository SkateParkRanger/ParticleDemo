using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    public ParticleSystem particleSystem; // Reference to your particle system
    public float speedMultiplier = 1.0f;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("AnalogStickX");
        float verticalInput = Input.GetAxis("AnalogStickY");

        Vector3 inputDirection = new Vector3(horizontalInput, 0f, verticalInput);

        if (inputDirection.magnitude > 0.1f) // Adjust dead zone as needed
        {
            Vector3 movementDirection = inputDirection.normalized;

            // Calculate the new direction for the particle system
            Vector3 newDirection = Quaternion.Euler(0f, transform.eulerAngles.y, 0f) * movementDirection;

            // Apply the new direction to the particle system's main module
            var mainModule = particleSystem.main;
            mainModule.startDirection = newDirection * speedMultiplier;
        }
    }
}