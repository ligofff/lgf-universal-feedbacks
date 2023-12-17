using System.Collections.Generic;
using DefaultNamespace;

public abstract class BaseUniversalFeedbacks_GameModule<T> : GameModuleBase where T : class
{
    protected abstract IEnumerable<BaseUniversalFeedbackEventSource<T>> Configs { get; }

    protected override void SetupModuleInternal()
    {
        foreach (var eventProviderFeedbackConfig in Configs)
        {
            eventProviderFeedbackConfig.Triggered += OnEventProviderTriggered;
            eventProviderFeedbackConfig.SetupEventListener();
        }
    }

    private void OnEventProviderTriggered(BaseFeedbackObject<T> arg1, BaseFeedbackObject<T> arg2, BaseFeedbackOption<T> arg3)
    {
        if (!arg1.IsValid()) return;
                
        arg3.PlayFeedback(arg1.Object);
    }

    protected override void DisposeModuleInternal()
    {
        foreach (var eventProviderFeedbackConfig in Configs)
        {
            eventProviderFeedbackConfig.Triggered -= OnEventProviderTriggered;
            eventProviderFeedbackConfig.DisposeEventListener();
        }
    }
}