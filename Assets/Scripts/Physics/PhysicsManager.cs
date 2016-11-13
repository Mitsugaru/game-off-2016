using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

public class PhysicsManager : View, IPhysicsManager
{

    [Inject]
    public IEventManager EventManager { get; set; }

    // Use this for initialization
    protected override void Start()
    {
        base.Start();

        EventManager.AddListener<CollidedEvent>(HandleCollided);
    }

    // Update is called once per frame
    void Update()
    {
        //For ignored objects, need to re apply collisions based on
        // the players raycast and what is between them
    }

    private void HandleCollided(CollidedEvent e)
    {

    }
}
