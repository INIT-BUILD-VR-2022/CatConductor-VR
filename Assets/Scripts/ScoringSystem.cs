using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    public rotation rotScript;
    public CartStats stats;
    public PrefabTrigger terrianScript;

    public int levelLengthInInt;
    private int nextThreshold = 0;

    void Start()
    {
        nextThreshold += levelLengthInInt;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        stats.score += (int)(10 * rotScript.rotationSpeed);
        
        if(stats.score >= nextThreshold)
        {
            terrianScript.changeTerrian();
            nextThreshold += levelLengthInInt;
        }
        
    }
}
