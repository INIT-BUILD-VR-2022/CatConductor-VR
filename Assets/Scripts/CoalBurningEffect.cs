using UnityEngine;

public class CoalBurningEffect : MonoBehaviour
{
    public Renderer coalRenderer; // Reference to the coal renderer
    public float burnTime = 10f; // Total burn time
    public Color startColor; // Initial color of the coal
    public Color endColor; // Final color of the coal
    public float startEmission = 0f; // Initial emission intensity
    public float endEmission = 1f; // Final emission intensity

    private float currentTime = 0f; // Current time elapsed

    void Start()
    {
        // Initialize the coal renderer material properties
        coalRenderer.material.color = startColor;
        coalRenderer.material.SetColor("_EmissionColor", startColor * startEmission);
    }

    void Update()
    {
        // Update the current time elapsed
        currentTime += Time.deltaTime;

        // Calculate the progress of the burning effect (0 to 1)
        float progress = Mathf.Clamp01(currentTime / burnTime);

        // Interpolate between start and end color based on progress
        Color currentColor = Color.Lerp(startColor, endColor, progress);
        coalRenderer.material.color = currentColor;

        // Interpolate between start and end emission intensity based on progress
        float currentEmission = Mathf.Lerp(startEmission, endEmission, progress);
        coalRenderer.material.SetColor("_EmissionColor", currentColor * currentEmission);
    }
}
