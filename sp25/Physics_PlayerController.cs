using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Physics_PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] Vector3 movement; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // rigidbody = gameObject.GetComponent<RigidBody>();
        rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    // FixedUpdate is good for Rigidbody Physics
    void FixedUpdate() {
        // Call the function we created to move the player
        movePlayer(movement);
    }

    // MovePlayer
    void movePlayer(Vector3 direction) {
        // multiply the direction * speed 
        rigidbody.AddForce(direction * speed);
    }

}
