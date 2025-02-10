using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Speed of the player's movement, adjustable in the Unity Inspector
    [SerializeField] private float speed = 2.0f;
    
    // Reference to the character GameObject (not used in movement logic yet)
    public GameObject character;

    void Update () {
        // Move right when the Right Arrow key is pressed
        if (Input.GetKey(KeyCode.RightArrow)){
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        
        // Move left when the Left Arrow key is pressed
        if (Input.GetKey(KeyCode.LeftArrow)){
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        
        // Move forward when the Up Arrow key is pressed
        if (Input.GetKey(KeyCode.UpArrow)){
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        
        // Move backward when the Down Arrow key is pressed
        if (Input.GetKey(KeyCode.DownArrow)){
            transform.position += Vector3.back * speed * Time.deltaTime;
        }
    }
}
