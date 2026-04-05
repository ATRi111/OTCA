using System.Text;
using UnityEngine;

public class PositionChangeEffect : Effect
{
    public Vector3Int from, to;

    public PositionChangeEffect(Entity victim, Vector3Int from, Vector3Int to, int probability = MaxProbability)
        : base(victim, probability)
    {
        this.from = from;
        this.to = to;
    }

    public override void Apply()
    {
        victim.GridObject.CellPosition = to;
    }

    public override void Describe(StringBuilder sb, bool result)
    {
        if (from == to)
            return;
        base.Describe(sb, result);
        sb.Append("从");
        sb.Append(from);
        sb.Append("移动到");
        sb.Append(to);
        sb.AppendLine();
    }
}
