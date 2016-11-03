using UnityEngine;

public class PortalSideTriggerScript : MonoBehaviour
{
    [Inject]
    public IEventManager EventManager { get; set; }

    public ColorLayer layer = ColorLayer.Normal;

    public PortalSideTriggerScript otherSide;

    public bool ignore = false;

    void OnTriggerEnter(Collider collider)
    {
        if (!ignore && collider.tag.Equals("Player"))
        {
            otherSide.ignore = true;
            EventManager.Raise(new ColorLayerChangedEvent(layer, true));
        }
    }

    void OnTriggerExit(Collider collider)
    {
        ignore = false;
    }
}
