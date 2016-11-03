using UnityEngine;
using System.Collections;

[System.Serializable]
public class PortalSide
{

    public GameObject sidePanel;

    public GameObject sideCamera;

    public Light sideLight;

    public ColorLayer layer = ColorLayer.Normal;

    public PortalSideTriggerScript triggerScript;
}
