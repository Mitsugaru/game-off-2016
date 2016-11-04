using strange.extensions.mediation.impl;
using UnityEngine;

public class MagicPaneScript : View
{
    [Inject]
    public IMaterialManager MaterialManager { get; set; }

    public GameObject Magic;

    public GameObject Glass;
    public ColorLayer layer = ColorLayer.Normal;

    private ColorLayer currentLayer = ColorLayer.Normal;

    private Renderer magicRenderer;

    private Renderer glassRenderer;
    // Use this for initialization
    protected override void Start()
    {
        magicRenderer = Magic.GetComponent<Renderer>();
        glassRenderer = Glass.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Update the pane to the newly selected layer
        if (currentLayer != layer)
        {
            // update the magic layer with the correct depth bit
            MaterialInfo pair = MaterialManager.GetMaterialPair(layer);
            magicRenderer.material.SetFloat("_StencilMask", pair.depth);

            //Update the glass color
            Color glassColor = CameraUtils.TranslateLayerToColor(layer);
            glassColor.a = 0.5f;
            glassRenderer.material.color = glassColor;
            currentLayer = layer;
        }
    }
}
