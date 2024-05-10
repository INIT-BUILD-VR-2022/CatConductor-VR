using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMap : MonoBehaviour
{
    public Material grassMaterial;
    public Material volcanicMaterial; 
    public GameObject[] mountainSegments; // Assign all 8 segments in the inspector
    private bool volcanicActive = false;

    private bool isChangingTexture = false;

    // Update is called once per frame
    void Update()
    {
        // Detect Q key press to toggle texture change
        if (Input.GetKeyDown(KeyCode.Q))
        {
            volcanicActive = !volcanicActive; // Toggle state
            Material chosenMaterial = volcanicActive ? volcanicMaterial : grassMaterial;

            // Change textures of all segments immediately
            foreach (GameObject segment in mountainSegments)
            {
                MeshRenderer meshRenderer = segment.GetComponent<MeshRenderer>();
                if (meshRenderer != null)
                {
                    meshRenderer.material = chosenMaterial;
                }
            }
        }
    }

    // This method is called by the trigger to change the texture of the specific segment
    public void ChangeSegmentTexture(GameObject segment)
    {
        if (volcanicActive) // Only change the texture if volcanic mode is active
        {
            MeshRenderer meshRenderer = segment.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.material = volcanicMaterial;
            }
        }
    }
}
