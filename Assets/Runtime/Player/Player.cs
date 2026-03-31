using Character;
using EditorExtend.GridEditor;
using Services;
using Services.Event;
using UnityEngine;

public class Player : EntityBase
{
    public static Player FindInstance()
    {
        return GameObject.Find("Player").GetComponent<Player>();
    }

    public IEventSystem EventSystem { get; private set; }
    [AutoComponent]
    public GridObject GridObject { get; private set; }

    [SerializeField]
    private int printingSupply;
    public int PrintingSupply
    {
        get => printingSupply;
        set
        {
            if (printingSupply != value)
            {
                printingSupply = value;
                EventSystem.Invoke(EEvent.OnPrintingSupplyChange, printingSupply, value);
            }
        }
    }

    protected override void Awake()
    {
        base.Awake();
        EventSystem = ServiceLocator.Get<IEventSystem>();
    }
}
