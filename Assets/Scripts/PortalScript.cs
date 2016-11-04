using UnityEngine;
using UnityStandardAssets.ImageEffects;
using strange.extensions.mediation.impl;

public class PortalScript : View
{
    [Inject]
    public IRootContext RootContext { get; set; }

    [Inject]
    public IEventManager EventManager { get; set; }

    public PortalSide SideA;

    public PortalSide SideB;

    private ColorLayer sideACurrent = ColorLayer.Normal;

    private ColorLayer sideBCurrent = ColorLayer.Normal;

    private RenderTexture SideARenderTexture;

    private RenderTexture SideBRenderTexture;

    private Material SideARenderMaterial;

    private Material SideBRenderMaterial;

    private ColorLayer currentLayer = ColorLayer.Normal;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();

        SideA.triggerScript.layer = SideA.layer;
        SideB.triggerScript.layer = SideB.layer;
        if (SideA.sideCamera != null)
        {
            SideARenderTexture = new RenderTexture(256, 256, 24, RenderTextureFormat.ARGB32);
            SideARenderTexture.Create();
            SideA.sideCamera.GetComponent<Camera>().targetTexture = SideARenderTexture;

            SideARenderMaterial = new Material(Shader.Find("Standard"));
            SideARenderMaterial.SetTexture("_MainTex", SideARenderTexture);
            SideA.sidePanel.GetComponent<Renderer>().material = SideARenderMaterial;
        }
        if (SideB.sideCamera != null)
        {
            SideBRenderTexture = new RenderTexture(256, 256, 24, RenderTextureFormat.ARGB32);
            SideBRenderTexture.Create();
            SideB.sideCamera.GetComponent<Camera>().targetTexture = SideBRenderTexture;

            SideBRenderMaterial = new Material(Shader.Find("Standard"));
            SideBRenderMaterial.SetTexture("_MainTex", SideBRenderTexture);
            SideB.sidePanel.GetComponent<Renderer>().material = SideBRenderMaterial;
        }

        RootContext.Inject(SideA.triggerScript);
        RootContext.Inject(SideB.triggerScript);

        EventManager.AddListener<ColorLayerChangedEvent>(HandleColorLayerChanged);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        Destroy(SideARenderMaterial);
        Destroy(SideBRenderMaterial);
        Destroy(SideARenderTexture);
        Destroy(SideBRenderTexture);
    }

    // Update is called once per frame
    void Update()
    {
        // Update A to its layer
        if (sideACurrent != SideA.layer)
        {
            //Update lighting colors
            SideA.sideLight.color = CameraUtils.TranslateLayerToColor(SideA.layer);
            CameraUtils.AdjustColorCorrectionCurves(currentLayer, SideA.layer, SideA.sideCamera);
            CameraUtils.SetCameraCullingMask(SideA.layer, SideA.sideCamera.GetComponent<Camera>());
            SideA.triggerScript.layer = SideA.layer;
            sideACurrent = SideA.layer;
        }

        if (sideBCurrent != SideB.layer)
        {
            SideB.sideLight.color = CameraUtils.TranslateLayerToColor(SideB.layer);
            CameraUtils.AdjustColorCorrectionCurves(currentLayer, SideB.layer, SideB.sideCamera);
            CameraUtils.SetCameraCullingMask(SideB.layer, SideB.sideCamera.GetComponent<Camera>());
            SideB.triggerScript.layer = SideB.layer;
            sideBCurrent = SideB.layer;
        }
    }

    private void HandleColorLayerChanged(ColorLayerChangedEvent e)
    {
        currentLayer = e.Layer;
        CameraUtils.AdjustColorCorrectionCurves(currentLayer, SideA.layer, SideA.sideCamera);
        CameraUtils.AdjustColorCorrectionCurves(currentLayer, SideB.layer, SideB.sideCamera);
    }
}
