using UnityEngine;

public class CollidedEvent : PhysicsEvent
{
    private Collision collision;
    public Collision Collision
    {
        get
        {
            return collision;
        }
    }

    private GameObject source;
    public GameObject Source
    {
        get
        {
            return source;
        }
    }

    public CollidedEvent(GameObject source, Collision collision)
    {
        this.source = source;
        this.collision = collision;
    }
}
