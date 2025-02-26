using UnityEngine;

public class Transform_PlayerController : MonoBehaviour
{
    // Speed of the player's movement
    [SerializeField] private float speed = 5.0f;

    // Referencing the GameObject (Cube) or our Player
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKey(KeyCode.D))
        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        // if (Input.GetKey(KeyCode.A))
        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        // if (Input.GetKey(KeyCode.W))
        if (Input.GetKey(KeyCode.UpArrow)) 
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        // if (Input.GetKey(KeyCode.S))
        if (Input.GetKey(KeyCode.DownArrow)) 
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }
    
    }
}
