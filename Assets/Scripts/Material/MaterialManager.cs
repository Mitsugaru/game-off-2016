using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

public class MaterialManager : View, IMaterialManager
{
    public MaterialInfo[] pairs;
    // Use this for initialization
    protected override void Start()
    {
        base.Start();
    }

    public MaterialInfo GetMaterialPair(ColorLayer layer)
    {
        MaterialInfo target = null;

        for (int i = 0; i < pairs.Length; i++)
        {
            if (pairs[i].layer.Equals(layer))
            {
                target = pairs[i];
                break;
            }
        }

        return target;
    }
}
