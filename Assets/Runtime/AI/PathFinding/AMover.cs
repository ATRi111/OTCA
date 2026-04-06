using AStar;

/// <summary>
/// 要寻路时，根据Pawn的属性、移动方式抽象出相应的AMover(或AMover子类)实例
/// </summary>
public abstract class AMover : MoverBase
{
    protected Pawn pawn;
    public AMover(Pawn pawn)
    {
        this.pawn = pawn;
    }

    public override bool StayCheck(Node node)
    {
        return base.StayCheck(node);
    }

    public override bool MoveCheck(Node from, Node to)
    {
        return base.MoveCheck(from, to);
    }

    public override float CalculateCost(Node from, Node to, float primitiveCost)
    {
        ANode aFrom = (ANode)from;
        ANode aTo = (ANode)to;
        float cost = primitiveCost * aTo.difficulty;
        return cost;
    }
}
