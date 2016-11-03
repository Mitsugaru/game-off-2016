using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

public class GameLayerManager : View, IGameLayerManager
{

    [Inject]
    public IEventManager EventManager { get; set; }

    private bool handledEntered = false;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();

        EventManager.AddListener<ColorLayerChangedEvent>(HandleColorLayerChanged);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void HandleColorLayerChanged(ColorLayerChangedEvent e)
    {
        if (e.Entered)
        {
            // We change the camera mask first to make it look to the player that its happening faster than it is.
            CameraUtils.SetCameraCullingMask(e.Layer, Camera.main);
            //TODO instead of doing color change on the camera
            // change the color of the colorables based on the layer we're exposing
            //CameraUtils.AdjustColorCorrectionCurves(e.Layer, Camera.main.gameObject);

            // Enable / Disable the appropriate colorable colliders
            GameObject[] colorables = GameObject.FindGameObjectsWithTag("Colorable");
            foreach (GameObject colorable in colorables)
            {
                Collider collider = colorable.GetComponent<Collider>();
                if (LayerMask.NameToLayer(e.Layer.ToString()).Equals(colorable.layer))
                {
                    if (collider != null)
                    {
                        collider.enabled = false;
                    }
                }
                else
                {
                    collider.enabled = true;
                }
            }
            handledEntered = true;
        }
    }
}
