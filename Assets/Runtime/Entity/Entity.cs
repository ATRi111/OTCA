using EditorExtend.GridEditor;
using Services;
using Services.Event;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private GridManagerBase gridManager;
    public IEventSystem EventSystem { get; private set; }
    public GridObject GridObject { get; private set; }
    public GridMoveController GridMoveController { get; private set; }

    public string entityName;
    /// <summary>
    /// 用于UI中的文本
    /// </summary>
    public string RichTextName => entityName;

    public virtual bool IsObstacle => false;

    protected virtual void Awake()
    {
        EventSystem = ServiceLocator.Get<IEventSystem>();
        gridManager = GetComponentInParent<GridManagerBase>();
        GridObject = GetComponent<GridObject>();
        GridMoveController = GetComponent<GridMoveController>();
    }
}
