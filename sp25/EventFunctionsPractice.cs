using UnityEngine;

public class EventFunctionsPractice : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Called only once when the component becomes enabled
    void Start()
    {
        Debug.Log("Start called:" + Time.deltaTime);
    }

    // Used to initialize variables or states before the application starts
    // Used when the GameObject becomes active for the first time
    void Awake()
    {
        Debug.Log("Awake called:" + Time.deltaTime);
    }

    // Called when the component in Unity is enabled and when it is turned on
    // In the Unity Editor, it is represented as a checkmark 
    void OnEnable()
    {
        Debug.Log("OnEnable called:" + Time.deltaTime);
    }

    // First we call OnEnable(), which is represented in the Unity Editor as an unmarked check box
    // Part of the decommissioning process. OnDestroy() is called after and is only called if we tell it to be destroyed
    void OnDisable() 
    {
        Debug.Log("OnDisable called:" + Time.deltaTime);
    }

    // Called every physics steps where the intervals are consistent
    // Used for regular updates and adjusting physics
    // Associated with Time.deltaTime and called at a fixed rate 
    // Take a look at the setting by going to Project Settings/Time/FixedTimeStep
    void FixedUpdate() 
    {
        Debug.Log("FixedUpdate called:" + Time.deltaTime);
    }

    // Update is called once per frame
    // This is the place for animation frames to make changes to position, state, and behavior of objects
    // For nonphysics animations
    void Update()
    {
        Debug.Log("Update called:" + Time.deltaTime);
    }
}
