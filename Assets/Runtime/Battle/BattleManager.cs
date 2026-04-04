using Services;
using System;
using System.Collections.Generic;

public class BattleManager : Service, IService
{
    [AutoService]
    private AnimationManager animationManager;
    public override Type RegisterType => typeof(BattleManager);

    public Queue<PawnAction> actionQueue = new();

    public PawnAction actionOnPlay;

    public void Register(PawnAction pawnAction)
    {
        actionQueue.Enqueue(pawnAction);
        if (!animationManager.IsPlaying)
        {
            actionOnPlay = actionQueue.Dequeue();
            actionOnPlay.Play(animationManager);
        }
    }

    public void AfterAction()
    {
        actionOnPlay?.Apply(animationManager);
        if (actionQueue.Count > 0)
        {
            actionOnPlay = actionQueue.Dequeue();
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
