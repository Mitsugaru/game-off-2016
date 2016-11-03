
public class ColorLayerChangedEvent : GameEvent
{

    private ColorLayer colorLayer;
    public ColorLayer Layer
    {
        get
        {
            return colorLayer;
        }
    }

    private bool entered = false;
    public bool Entered
    {
        get
        {
            return entered;
        }
    }

    public ColorLayerChangedEvent(ColorLayer layer, bool entered)
    {
        this.colorLayer = layer;
        this.entered = entered;
    }
}
