using AStar;

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
