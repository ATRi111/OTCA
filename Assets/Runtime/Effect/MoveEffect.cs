using System.Collections.Generic;
using UnityEngine;

public class MoveEffect : TeleportEffect
{
    public readonly List<Vector3> route;
    // 移动速度倍率（规定行走为1）
    public readonly float speedMultiplier;

    public MoveEffect(Entity victim, Vector3Int from, Vector3Int to, List<Vector3> route, float speedMultiplier = 1f, int probability = MaxProbability)
        : base(victim, from, to, probability)
    {
        this.route = route;
        this.speedMultiplier = speedMultiplier;
    }

    public override EntityAnimation GetAnimation()
    {
        if (route != null && route.Count > 1)
            return new MoveAnimation(victim, route, speedMultiplier);
        return base.GetAnimation();
    }
}
