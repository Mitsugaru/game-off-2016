using UnityEngine;
using System.Collections;

public interface IMaterialManager
{
    MaterialInfo GetMaterialPair(ColorLayer layer);
}
