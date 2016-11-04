using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

public class GameLayerManager : View, IGameLayerManager
{

    [Inject]
    public IEventManager EventManager { get; set; }

    public GameObject ground;

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

            // Adjust the environment color to the current layer
            // TODO maybe move this out to its own thing
            MeshRenderer groundRenderer = ground.GetComponent<MeshRenderer>();
            groundRenderer.material.color = CameraUtils.TranslateLayerToColor(e.Layer);

            // Enable / Disable the appropriate colorable colliders
            GameObject[] colorables = GameObject.FindGameObjectsWithTag("Colorable");
            foreach (GameObject colorable in colorables)
            {
                Collider collider = colorable.GetComponent<Collider>();
                if (collider != null)
                {
                    collider.enabled = !LayerUtils.MatchesLayerRules(e.Layer, colorable.layer);
                }
            }
        }
    }
}
