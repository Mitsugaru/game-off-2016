using System;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class CameraUtils
{

    public static void SetCameraCullingMask(ColorLayer layer, Camera camera)
    {
        if (camera != null)
        {
            switch (layer)
            {
                case ColorLayer.Red:
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Red");
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Green");
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Blue");
                    camera.cullingMask &= ~(1 << LayerMask.NameToLayer("Cyan"));
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Magenta");
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Yellow");
                    break;
                case ColorLayer.Green:
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Red");
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Green");
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Blue");
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Cyan");
                    camera.cullingMask &= ~(1 << LayerMask.NameToLayer("Magenta"));
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Yellow");
                    break;
                case ColorLayer.Blue:
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Red");
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Green");
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Blue");
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Cyan");
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Magenta");
                    camera.cullingMask &= ~(1 << LayerMask.NameToLayer("Yellow"));
                    break;
                case ColorLayer.Cyan:
                    camera.cullingMask &= ~(1 << LayerMask.NameToLayer("Red"));
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Green");
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Blue");
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Cyan");
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Magenta");
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Yellow");
                    break;
                case ColorLayer.Magenta:
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Red");
                    camera.cullingMask &= ~(1 << LayerMask.NameToLayer("Green"));
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Blue");
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Cyan");
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Magenta");
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Yellow");
                    break;
                case ColorLayer.Yellow:
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Red");
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Green");
                    camera.cullingMask &= ~(1 << LayerMask.NameToLayer("Blue"));
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Cyan");
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Magenta");
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Yellow");
                    break;
                default:
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Red");
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Green");
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Blue");
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Cyan");
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Magenta");
                    camera.cullingMask |= 1 << LayerMask.NameToLayer("Yellow");
                    break;
            }
        }
    }

    public static void AdjustColorCorrectionCurves(ColorLayer previousLayer, ColorLayer newLayer, GameObject camera)
    {
        ColorCorrectionCurves curves = camera.GetComponent<ColorCorrectionCurves>();

        if (curves != null)
        {
            curves.selectiveFromColor = TranslateLayerToColor(previousLayer);
            curves.selectiveToColor = TranslateLayerToColor(newLayer);
            curves.selectiveCc = true;
        }

        curves.UpdateParameters();
    }

    public static Color TranslateLayerToColor(ColorLayer layer)
    {
        Color c = Color.white;

        switch (layer)
        {
            case ColorLayer.Red:
                c = Color.red;
                break;
            case ColorLayer.Green:
                c = Color.green;
                break;
            case ColorLayer.Blue:
                c = Color.blue;
                break;
            case ColorLayer.Cyan:
                c = Color.cyan;
                break;
            case ColorLayer.Magenta:
                c = Color.magenta;
                break;
            case ColorLayer.Yellow:
                c = Color.yellow;
                break;
            default:
                break;
        }

        return c;
    }
}
