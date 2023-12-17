﻿using System;
using UnityEngine;

[Serializable]
public abstract class BaseFeedbackOption<T>
{
    public void PlayFeedback(T obj)
    {
        if (!IsValidForFeedback(obj))
        {
            Debug.LogWarning($"Cannot play feedback! Feedback: {GetType().Name}, Object: {obj}");
            return;
        }
            
        if (!IsCanPlay(obj)) return;
            
        PlayFeedbackInternal(obj);
    }

    protected abstract void PlayFeedbackInternal(T entity);
        
    public void StopFeedback(T obj)
    {
        if (!IsValidForFeedback(obj))
        {
            Debug.LogWarning($"Cannot stop feedback! Feedback: {GetType().Name}, Object: {obj}");
            return;
        }
            
        StopFeedbackInternal(obj);
    }

    protected abstract void StopFeedbackInternal(T obj);

    public bool IsCanPlay(T obj)
    {
        return IsCanPlayInternal(obj);
    }

    protected virtual bool IsCanPlayInternal(T obj) => true;

    protected abstract bool IsValidForFeedback(T obj);
}