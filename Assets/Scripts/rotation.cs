using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{

    [HideInInspector] public float baseRotationSpeed = .5f;
    // Initial rotation speed
    [HideInInspector] public float rotationSpeed = .5f;

    // speed increase rate per second
    private float speedIncreaseRate = 0.2f;

    //rate of slowing down
    private float slowDownRate = 0.1f;

    // Minimum and maximum rotation speed
    private float minRotationSpeed = 0.1f;
    private float maxRotationSpeed = 1.9f;

    //public spawningObstacles spawnScript;


    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate() {
        
     

        
        if (Input.GetKey(KeyCode.Z))
        {
            SpeedUpRotation();
        }

        if (Input.GetKey(KeyCode.X))
        {
            SlowDownRotation();
        }


        transform.Rotate(0f, rotationSpeed, 0f, Space.Self);
    }

    

    // Slowly increase in speed at a slow rate over time in int
    //be able to slow down a set amount but not to zero
    //dummy
    public void SpeedUpRotation()
    {
        // Increase rotation speed
        rotationSpeed += speedIncreaseRate * Time.deltaTime;

        // maximum speed
        rotationSpeed = Mathf.Clamp(rotationSpeed, minRotationSpeed, maxRotationSpeed);
    }

    public void SlowDownRotation()
    {
        rotationSpeed -= slowDownRate * Time.deltaTime;

        rotationSpeed = Mathf.Clamp(rotationSpeed, minRotationSpeed, maxRotationSpeed);
    }



    //capture the speed, then slow it down, then after slow down timer has elapsed, rapidly build up back to original speed
}
