using Services;
using System;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : Service, IService
{
    public override Type RegisterType => typeof(AnimationManager);

    public bool IsPlaying => animationList.Count > 0;
    [SerializeField]
    private HashSet<EntityAnimation> animationList = new();

    public Action AfterActionAnimation;

    public void Register(EntityAnimation animation, bool playOnRegister = true)
    {
        animationList.Add(animation);
        if (playOnRegister)
            animation.Play();
    }

    public void Unregister(EntityAnimation animation)
    {
        animationList.Remove(animation);
        if (!IsPlaying)
            AfterActionAnimation?.Invoke();
    }
}
