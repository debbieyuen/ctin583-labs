using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    [SerializeField] CharacterController characterController;
    [SerializeField] float speed = 10.0f;
    [SerializeField] Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movePlayer(movement);
    }

    void movePlayer(Vector3 direction)
    {
        characterController.Move(movement * Time.deltaTime * speed);
    }

}
