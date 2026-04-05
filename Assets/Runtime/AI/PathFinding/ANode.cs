using AStar;
using EditorExtend.GridEditor;
using UnityEngine;

public class ANode : Node
{
    protected GridManagerBase gridManager;
    public GridObject gridObject;
    public Entity entity;
    public Vector3Int cellPosition;

    protected bool isObstacle;
    public override bool IsObstacle => isObstacle;
    public bool isEntity;

    public float difficulty;    //对移动力的影响体现在AMover中(因为可能有AMover无视移动难度)

    public ANode(PathFindingProcess process, Vector2Int position, GridManagerBase gridManager) :
        base(process, position)
    {
        this.gridManager = gridManager;
        gridObject = gridManager.GetObjectXY(position);
        if (gridObject != null)
        {
            entity = gridObject.GetComponent<Entity>();
            isObstacle = entity != null && entity.IsObstacle;
            difficulty = 1;
        }
        else //空地
        {
            difficulty = 1;
        }
    }
}
