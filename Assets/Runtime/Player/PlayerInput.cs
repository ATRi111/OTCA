using EditorExtend.GridEditor;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private GridManagerBase gridManager;
    private GridObject gridObject;
    private GridMoveController moveController;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 screen = Input.mousePosition;
            Vector3 world = Camera.main.ScreenToWorldPoint(screen).ResetZ();
            Vector3Int to = gridManager.WorldToCell(world);
            Vector3Int from = gridObject.CellPosition;
            moveController.ForceComplete();
            moveController.SetRoute(new List<Vector3> { from, to });
        }
    }

    private void Awake()
    {
        gridObject = GetComponent<GridObject>();
        moveController = GetComponent<GridMoveController>();
        gridManager = GetComponentInParent<GridManagerBase>();
    }
}
