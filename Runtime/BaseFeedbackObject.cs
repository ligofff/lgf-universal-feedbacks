using System;
using UnityEngine;

public abstract class BaseFeedbackObject<T> where T : class
{
    public event Action<T> Destroyed;

    protected T _obj;

    public T Object => _obj;

    public abstract bool IsValid();

    protected BaseFeedbackObject(T obj)
    {
        _obj = obj;
    }

    public abstract void SubscribeToDestroyEvents();
    public abstract void UnsubscribeFromDestroyEvents();

    protected void InvokeDestroyedEvent(T obj)
    {
        Destroyed?.Invoke(obj);
    }
}