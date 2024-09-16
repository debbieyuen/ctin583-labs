using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        // rigidbody = gameObject.GetComponent<Rigidbody>();
        rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    // FixedUpdate is good for Rigidbody Physics
    private void FixedUpdate()
    {
        // Call the function that we created
        movePlayer(movement);
    }

    void movePlayer(Vector3 direction)
    {
        // transform.Translate(direction * speed * Time.deltaTime);
        rigidbody.AddForce(direction * speed);
        // rigidbody.MovePosition(transform.position + (direction * speed * Time.deltaTime));
    }

}

