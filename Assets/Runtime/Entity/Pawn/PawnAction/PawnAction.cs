using System.Collections.Generic;

[System.Serializable]
public abstract class PawnAction
{
    private List<Effect> effects = new();
    //必须确保前面的Action执行完，再确定此Action的结果
    protected abstract void GenerateEffect(List<Effect> effects);

    public void Play(AnimationManager animationManager)
    {
        GenerateEffect(effects);
        for (int i = 0; i < effects.Count; i++)
        {
            EntityAnimation animation = effects[i].GetAnimation();
            if (animation != null)
                animationManager.Register(animation);
        }
    }

    public void Apply(AnimationManager animationManager)
    {
        for (int i = 0; i < effects.Count; i++)
        {
            effects[i].Apply();
        }
    }
}
