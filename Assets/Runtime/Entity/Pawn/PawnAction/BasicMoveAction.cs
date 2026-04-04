using System.Collections.Generic;
using UnityEngine;

//一格移动
public class BasicMoveAction : PawnAction
{
    public Vector3Int direction;
    public Entity victim;

    public BasicMoveAction(Entity victim, Vector3Int direction)
        : base()
    {
        this.direction = direction;
        this.victim = victim;
    }

    protected override void GenerateEffect(List<Effect> effects)
    {
        Vector3Int from = victim.GridObject.CellPosition;
        Vector3Int to = from + direction;
        MoveEffect moveEffect = new(victim, from, to, new List<Vector3> { from, to }, 1f);
        effects.Add(moveEffect);
    }
}
