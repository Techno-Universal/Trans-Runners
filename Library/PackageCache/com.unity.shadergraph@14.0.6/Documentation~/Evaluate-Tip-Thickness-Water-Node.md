# Evaluate Tip Thickness

This node calculates the thickness of the water at the tips of waves.

The High Definition Render Pipeline (HDRP) uses this node in the default water shader graph. See the HDRP documentation for more information about [the Water System](https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@14.0/manual/WaterSystem.html).

## Render pipeline compatibility

| **Node**               | **Universal Render Pipeline (URP)** | **High Definition Render Pipeline (HDRP)** |
| ---------------------- | ----------------------------------- | ------------------------------------------ |
| **Evaluate Tip Thickness** | No                                  | Yes                                        |

## Ports

| **Name** | **Direction** | **Type** | **Description** |
|--- | --- | --- | --- |
| **LowFrequencyNormal** | Input | Vector3 | The low frequency normal of the water surface in world space. This is the normal of the water surface without high frequency details such as ripples. |
| **LowFrequencyHeight** | Input | Float | The vertical displacement of the water surface. This doesn't include ripples.|
| **TipThickness** | Output | Float | The thickness of the water in a wave tip. |