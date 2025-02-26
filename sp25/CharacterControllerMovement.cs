using UnityEngine;

public class CharacterControllerMovement : MonoBehaviour
{
    // Define Character Controller
    [SerializeField] CharacterController characterController;

    [SerializeField] float speed = 10.0f;
    [SerializeField] Vector3 movement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Locate our character controller component
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical"));
        movePlayer(movement);
    }

    void movePlayer(Vector3 direction) {
        characterController.Move(movement * speed * Time.deltaTime);
    }
}
