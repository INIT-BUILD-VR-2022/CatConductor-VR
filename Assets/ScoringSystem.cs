using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    public rotation rotScript;
    public CartStats stats;

    // Update is called once per frame
    void FixedUpdate()
    {
        stats.score += (int)(10 * rotScript.rotationSpeed);
        
    }
}
