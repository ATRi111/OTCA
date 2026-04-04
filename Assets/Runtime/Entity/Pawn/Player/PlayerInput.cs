using Services;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private BattleManager battleManager;
    private Player player;

    public Dictionary<KeyCode, Vector3Int> moveDirections = new()
    {
        { KeyCode.W, Vector3Int.up },
        { KeyCode.S, Vector3Int.down },
        { KeyCode.A, Vector3Int.left },
        { KeyCode.D, Vector3Int.right }
    };

    private void Update()
    {
        Vector3Int moveDirection = Vector3Int.zero;
        foreach (var direction in moveDirections)
        {
            if (Input.GetKeyUp(direction.Key))
            {
                moveDirection = direction.Value;
                break;
            }
        }
        if (moveDirection != Vector3Int.zero)
        {
            BasicMoveAction moveAction = new(player, moveDirection);
            battleManager.Register(moveAction);
        }
    }

    private void Awake()
    {
        player = GetComponent<Player>();
        battleManager = ServiceLocator.Get<BattleManager>();
    }
}
