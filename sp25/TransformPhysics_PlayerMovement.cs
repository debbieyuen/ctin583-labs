using UnityEngine;
using UnityEngine.InputSystem;

public class TransformPhysics_PlayerMovement : MonoBehaviour
{
    // Unity's New Input System
    [SerializeField] private InputAction movementInputs;

    // player speed based on input
    [SerializeField] float controlSpeed = 10f;

    // Determines how much the player should move horizontally (x) and vertically (z) axes per frame
    // how far player can move horizontally 
    [SerializeField] float xRange = 10f;
    // how far player can move vertically
    [SerializeField] float zRange = 10f;

    // pitch controls the up/down tilt of the player
    // yaw controls the rotations around the y-axis: allows the player to turn left/right based on a horizontal position
    // roll refers to horizontal movement and tilting effects - side movement 
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float controlPitchFactor = 10f;
    [SerializeField] float controlRollFactor = -20f;

    // Read the inputs from the movement actions. We want to define the variables here 
    private float xThrow;
    private float zThrow;

    // Enable/Disable the input actions when the object becomes active/inactive
    // Activates the input action when the script is enabled 
    void OnEnable() {
        movementInputs.Enable();
    }
    // Decactivates the input action when the script is disabled
    void OnDisable() {
        movementInputs.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    void ProcessRotation() {
        // calculate the player's pitch, yaw, and roll based on movement and position
        float pitchDueToPosition = transform.localPosition.z * positionPitchFactor;
        float pitchDueToControlThrow = zThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;
    }

    void ProcessTranslation() {
        // Read the player input values for movement
        xThrow = movementInputs.ReadValue<Vector2>().x; 
        zThrow = movementInputs.ReadValue<Vector2>().y;

        // Calculate the movement offset based on input and speed
        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        float zOffset = zThrow * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset; 
        float rawZPos = transform.localPosition.z + zOffset;

        // Clamp the player's position within defined boundaries 
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float clampedZPos = Mathf.Clamp(rawZPos, -zRange, zRange);

        // Apply the new position to the player
        transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, clampedZPos);
    }
}
