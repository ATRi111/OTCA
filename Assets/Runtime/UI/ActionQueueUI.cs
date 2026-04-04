using Services;
using UnityEngine;

public class ActionQueueUI : MonoBehaviour
{
    private BattleManager battleManager;
    private ActionImage[] actionImages;

    private void OnActionQueueUpdate()
    {
        int visibleCount = Mathf.Min(actionImages.Length, battleManager.actionQueue.Count);
        PawnAction[] actions = battleManager.actionQueue.ToArray();
        int i = 0;
        for (; i < visibleCount; i++)
        {
            actionImages[i].SetAction(actions[i]);
        }
        for (; i < actionImages.Length; i++)
        {
            actionImages[i].SetAction(null);
        }
    }

    private void Awake()
    {
        actionImages = GetComponentsInChildren<ActionImage>(true);
        battleManager = ServiceLocator.Get<BattleManager>();
        battleManager.OnActionQueueUpdate += OnActionQueueUpdate;
    }

    private void Start()
    {
        OnActionQueueUpdate();
    }
}
