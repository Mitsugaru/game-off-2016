using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

public class ColliderNotifier : View
{
    [Inject]
    public IEventManager EventManager { get; set; }

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {

    }
}
