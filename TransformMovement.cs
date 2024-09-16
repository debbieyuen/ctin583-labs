using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMovement : MonoBehaviour
{
    private GameObject Sphere;
    private GameObject Cube;
    private float speed;
    void Update() {
        // Move the object forward along its z axis 1 unit/second
        // The cube is ridiculously moving fast to the right! 
        // That’s because transform.Translate(Vector3.right); is same as 
        // ‘move the cube to right by 1 unit (same as 1 meter in real world) per frame. 
        // Now, Unity’s ‘void Update’ speed is about 60 frames per second in average
        transform.Translate(Vector3.forward * Time.deltaTime);

        // Move the object upward in world space 1 unit/second
        // The function Time.deltaTime converts the speed into a real time
        transform.Translate(Vector3.up * Time.deltaTime, Space.World);

        // Move the object towards another object
        Sphere = transform.position = Vector3.MoveTowards(Sphere.transform.position, Cube.transform.position, speed);

        transform.positin = new Vector3(0, 0, 0);

    }
}
