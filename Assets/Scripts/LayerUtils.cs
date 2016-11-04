using UnityEngine;

public class LayerUtils
{

    public static bool MatchesLayerRules(ColorLayer layer, int targetLayer)
    {
        bool matches = false;
        string target = LayerMask.LayerToName(targetLayer);

        switch (layer)
        {
            case ColorLayer.Red:
                matches = target.Equals("Cyan");
                break;
            case ColorLayer.Green:
                matches = target.Equals("Magenta");
                break;
            case ColorLayer.Blue:
                matches = target.Equals("Yellow");
                break;
            case ColorLayer.Cyan:
                matches = target.Equals("Red");
                break;
            case ColorLayer.Magenta:
                matches = target.Equals("Green");
                break;
            case ColorLayer.Yellow:
                matches = target.Equals("Blue");
                break;
            default:
                break;
        }

        return matches;
    }
}
