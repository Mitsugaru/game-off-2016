using UnityEngine;

[System.Serializable]
public class MaterialInfo
{
    public ColorLayer layer;
    public LayerMask mask;
    public float depth = 0.0f;
    public Material basic;
    public Material hidden;

}
