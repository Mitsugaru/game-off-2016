using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class CameraUtils
{
    private static AnimationCurve standardCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

    private static AnimationCurve liveLinearCurve = AnimationCurve.Linear(0f, 1f, 1f, 1f);

    public static void SetCameraCullingMask(ColorLayer layer, Camera camera)
    {
        if (camera != null)
        {
            switch (layer)
            {
                case ColorLayer.Red:
                    camera.cullingMask &= ~(1 << LayerMask.NameToLayer("Red"));
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Green");
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Blue");
                    break;
                case ColorLayer.Green:
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Red");
                    camera.cullingMask &= ~(1 << LayerMask.NameToLayer("Green"));
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Blue");
                    break;
                case ColorLayer.Blue:
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Red");
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Green");
                    camera.cullingMask &= ~(1 << LayerMask.NameToLayer("Blue"));
                    break;
                default:
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Red");
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Green");
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Blue");
                    break;
            }
        }
    }

    public static void AdjustColorCorrectionCurves(ColorLayer layer, GameObject camera)
    {
        ColorCorrectionCurves curves = camera.GetComponent<ColorCorrectionCurves>();

        if (curves != null)
        {
            switch (layer)
            {
                case ColorLayer.Red:
                    curves.redChannel = liveLinearCurve;
                    curves.greenChannel = standardCurve;
                    curves.blueChannel = standardCurve;
                    break;
                case ColorLayer.Green:
                    curves.redChannel = standardCurve;
                    curves.greenChannel = liveLinearCurve;
                    curves.blueChannel = standardCurve;
                    break;
                case ColorLayer.Blue:
                    curves.redChannel = standardCurve;
                    curves.greenChannel = standardCurve;
                    curves.blueChannel = liveLinearCurve;
                    break;
                default:
                    curves.redChannel = standardCurve;
                    curves.greenChannel = standardCurve;
                    curves.blueChannel = standardCurve;
                    break;
            }
        }

        curves.UpdateParameters();
    }
}
