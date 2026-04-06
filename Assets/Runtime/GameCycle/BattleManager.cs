using Services;
using System;
using System.Collections.Generic;

public class BattleManager : Service, IService
{
    [AutoService]
    private AnimationManager animationManager;
    public override Type RegisterType => typeof(BattleManager);

    public Queue<PawnAction> actionQueue = new();
    public int ActiveActionCount => actionQueue.Count + (actionOnPlay == null ? 0 : 1);

    public PawnAction actionOnPlay;
    public Action OnActionQueueUpdate;

    public void Register(PawnAction pawnAction)
    {
        actionQueue.Enqueue(pawnAction);
        OnActionQueueUpdate?.Invoke();
        if (!animationManager.IsPlaying)
        {
            actionOnPlay = actionQueue.Peek();
            actionOnPlay.Play(animationManager);
        }
    }

    public void AfterAction()
    {
        actionOnPlay?.Apply(animationManager);
        actionQueue.Dequeue();
        OnActionQueueUpdate?.Invoke();
        if (actionQueue.Count > 0)
        {
            actionOnPlay = actionQueue.Peek();
            actionOnPlay.Play(animationManager);
        }
        else
        {
            actionOnPlay = null;
        }
    }

    protected internal override void Init()
    {
        base.Init();
        animationManager.AfterActionAnimation += AfterAction;
    }
}
