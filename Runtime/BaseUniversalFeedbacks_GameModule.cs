using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;

public abstract class BaseUniversalFeedbacks_GameModule<T> : GameModuleBase where T : class
{
    protected abstract IEnumerable<BaseUniversalFeedbackEventSource<T>> Configs { get; }

    public IEnumerable<string> SourceEventCodes => Configs.Select(source => source.eventCode);
    
    protected override void SetupModuleInternal()
    {
        foreach (var eventProviderFeedbackConfig in Configs)
        {
            eventProviderFeedbackConfig.Triggered += OnEventProviderTriggered;
            eventProviderFeedbackConfig.SetupEventListener();
        }
    }

    private void OnEventProviderTriggered(BaseFeedbackObject<T> arg1, BaseFeedbackObject<T> arg2, BaseFeedbackOption<T> arg3, BaseUniversalFeedbackEventSource<T> arg4)
    {
        if (!arg1.IsValid()) return;
                
        arg3.PlayFeedback(arg1.Object, arg4.eventCode);
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