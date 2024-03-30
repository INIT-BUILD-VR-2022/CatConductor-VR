Shader "Custom/BurningEffectShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {} // Main texture
        _BurnColor ("Burn Color", Color) = (1, 0.5, 0, 1) // Color when burning
        _BurnIntensity ("Burn Intensity", Range(0, 1)) = 0 // Intensity of burning effect
        _GlowColor ("Glow Color", Color) = (1, 0.5, 0, 1) // Color of glow
        _GlowIntensity ("Glow Intensity", Range(0, 1)) = 0 // Intensity of glow effect
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100
        
        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        // Shader properties
        sampler2D _MainTex;
        fixed4 _BurnColor;
        float _BurnIntensity;
        fixed4 _GlowColor;
        float _GlowIntensity;

        struct Input
        {
            float2 uv_MainTex;
        };

        // Surface shader function
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Sample the main texture
            fixed4 mainTexColor = tex2D(_MainTex, IN.uv_MainTex);

            // Calculate the final color based on burn intensity
            fixed4 finalColor = lerp(mainTexColor, _BurnColor, _BurnIntensity);

            // Apply emission for burning effect with increased glow intensity
            o.Emission = finalColor.rgb * _BurnIntensity * (_GlowIntensity * 2); // Adjusted for increased glow intensity

            // Apply final color
            o.Albedo = finalColor.rgb;

            // Apply smoothness and metallic from main texture
            o.Smoothness = mainTexColor.a;
            o.Metallic = mainTexColor.r;

            // Apply alpha
            o.Alpha = mainTexColor.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
