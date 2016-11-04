using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;
using strange.extensions.context.api;

public class RootContext : MVCSContext, IRootContext
{

    public RootContext(MonoBehaviour view) : base(view)
    {

    }

    public RootContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
    {

    }

    protected override void mapBindings()
    {
        base.mapBindings();

        GameObject managers = GameObject.Find("Managers");

        injectionBinder.Bind<IRootContext>().ToValue(this).ToSingleton().CrossContext();

        EventManager eventManager = managers.GetComponent<EventManager>();
        injectionBinder.Bind<IEventManager>().ToValue(eventManager).ToSingleton().CrossContext();

        IMaterialManager materialManager = managers.GetComponent<MaterialManager>();
        injectionBinder.Bind<IMaterialManager>().ToValue(materialManager).ToSingleton().CrossContext();

        ICameraLayerManager cameraManager = managers.GetComponent<ICameraLayerManager>();
        injectionBinder.Bind<ICameraLayerManager>().ToValue(cameraManager).ToSingleton().CrossContext();

        IGameLayerManager gameManager = managers.GetComponent<IGameLayerManager>();
        injectionBinder.Bind<IGameLayerManager>().ToValue(gameManager).ToSingleton().CrossContext();
    }

    public void Inject(Object o)
    {
        injectionBinder.injector.Inject(o);
    }
}
