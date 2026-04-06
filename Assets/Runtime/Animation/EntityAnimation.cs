using Services;

[System.Serializable]
public abstract class EntityAnimation
{
    private readonly AnimationManager animationManager;
    public Entity performer;

    public EntityAnimation(Entity performer)
    {
        this.performer = performer;
        animationManager = ServiceLocator.Get<AnimationManager>();
    }

    public abstract void Play();

    public virtual void AfterComplete()
    {
        animationManager.Unregister(this);
    }
}
