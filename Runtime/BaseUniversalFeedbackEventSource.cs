using System;
using UnityEngine;

[Serializable]
public abstract class BaseUniversalFeedbackEventSource<T> where T : class
{
    public abstract event Action<BaseFeedbackObject<T>, BaseFeedbackObject<T>, BaseFeedbackOption<T>> Triggered;

    protected abstract BaseFeedbackOption<T> Option { get; }

    public void SetupEventListener()
    {
        SetupEventListenerInternal();
    }

    protected abstract void SetupEventListenerInternal();
    
    public void DisposeEventListener()
    {
        DisposeEventListenerInternal();
    }

    protected abstract void DisposeEventListenerInternal();
}