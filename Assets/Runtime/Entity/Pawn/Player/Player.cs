using Services.Event;
using UnityEngine;

public class Player : Pawn
{
    public static Player FindInstance()
    {
        return GameObject.Find("Player").GetComponent<Player>();
    }

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
}
