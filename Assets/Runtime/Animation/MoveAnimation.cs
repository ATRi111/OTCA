using System.Collections.Generic;
using UnityEngine;

public class MoveAnimation : EntityAnimation
{
    private readonly GridMoveController controller;
    public readonly List<Vector3> route;
    public readonly float speedMultiplier;

    public MoveAnimation(Entity performer, List<Vector3> route, float speedMultiplier) : base(performer)
    {
        this.route = route;
        this.speedMultiplier = speedMultiplier;
        controller = performer.GridMoveController;
    }

    public override void Play()
    {
        controller.SetRoute(route);
        controller.AfterMove += AfterComplete;
    }

    public override void AfterComplete()
    {
        base.AfterComplete();
        controller.AfterMove -= AfterComplete;
    }
}
