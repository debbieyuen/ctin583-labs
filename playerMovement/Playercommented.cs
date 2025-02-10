using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TransformMovementPhysics : MonoBehaviour
{
    [Header("General Setup Settings")]
    // A serialized input action that defines the controls for player movement
    [SerializeField] private InputAction movement;
    
    // Controls the speed at which the player moves.
    [Tooltip("How fast player moves up and down based upon player input")][SerializeField] float controlSpeed = 30f;
    [Tooltip("How far player moves horizontally")][SerializeField] float xRange = 10f;
    [Tooltip("How far player moves vertically")][SerializeField] float zRange = 10f;

    [Header("Screen position based tuning")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float positionYawFactor = 2f;

    [Header("Player input based tuning")]
    [SerializeField] float controlPitchFactor = 10f;
    [SerializeField] float controlRollFactor = -20f;

    // Read input from the movement action. These values represent the player's intended movement along the X and Z axes.
    private float xThrow;
    private float zThrow;

    // Activates the input action when the script is enabled.
    private void OnEnable()
    {
        movement.Enable();
    }
    
    // Deactivates the input action when the script is disabled.
    private void OnDisable()
    {
        movement.Disable();
    }

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        // Calculate the player's pitch, yaw, and roll based on movement and position.
        float pitchDueToPosition = transform.localPosition.z * positionPitchFactor;
        float pitchDueToControlThrow = zThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        // Apply rotation (roll not implemented yet, but can be added using controlRollFactor).
    }

    private void ProcessTranslation()
    {
        // Read the player input values for movement.
        xThrow = movement.ReadValue<Vector2>().x;
        zThrow = movement.ReadValue<Vector2>().y;

        // Calculate the movement offset based on input and speed.
        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float zOffset = zThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float rawZPos = transform.localPosition.z + zOffset;

        // Clamp the player's position within defined boundaries.
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float clampedZPos = Mathf.Clamp(rawZPos, -zRange, zRange);

        // Apply the new position to the player.
        transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, clampedZPos);
    }
}