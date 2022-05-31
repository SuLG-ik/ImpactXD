using System;
using Lifecycle;
using UnityEngine;

public abstract class CompatComponent : MonoBehaviour, LifecycleOwner

{
    private LifecycleImpl lifecycleImpl = new LifecycleImpl();

    public ILifecycle GetLifecycle()
    {
        return lifecycleImpl;
    }

    private void OnDestroy()
    {
        lifecycleImpl.SendEvent(ILifecycle.Event.Destroy);
        lifecycleImpl.Clear();
    }
}