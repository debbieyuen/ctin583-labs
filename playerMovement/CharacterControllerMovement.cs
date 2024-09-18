using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerMovement : MonoBehaviour
{
    // Define Character Controller (private)
    [SerializeField] CharacterController characterController;
    // Add a speed variable so we can use it in the Move command
    // a float is a value type that represents fractional parts
    // represents one or more decimals
    [SerializeField] float speed = 10.0f;
    [SerializeField] Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        // Want to grab our component (private)
        // locate this component in Unity
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Input.GetAxis returns the value of the virtual axis between the ranges of -1 and 1
        // We are getting the horizontal and vertical axis
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // clean up the code we can create a new method movePlayer
        movePlayer(movement);
    }

    void movePlayer(Vector3 direction)
    {
        // Move our character controller with move
        // Move takes in a Vector3 so we will need to define a vector 3
        // Move motoin moves the GameObject in the gi ven direction. The given direction
        // requires absolute movement delta values. 
        characterController.Move(movement * Time.deltaTime * speed);
    }

}
