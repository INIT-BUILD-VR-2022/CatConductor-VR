using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningWheels : MonoBehaviour
{

    private List<Transform> wheels = new List<Transform>();
    public rotation rotScript;
    private float rotationSpeed;
    void Start()
    {
        foreach (Transform child in transform)
        {
            wheels.Add(child.transform);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rotationSpeed = rotScript.rotationSpeed * 8;
        foreach (Transform wheel in wheels)
        {
            wheel.Rotate(rotationSpeed, 0f, 0f, Space.Self);
        }
    }
}
