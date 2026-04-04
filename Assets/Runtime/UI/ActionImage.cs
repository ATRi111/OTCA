using TMPro;
using UIExtend;
using UnityEngine;

public class ActionImage : MonoBehaviour
{
    private TextMeshProUGUI tmp;
    private CanvasGroupPlus canvasGroup;

    private void Awake()
    {
        tmp = GetComponentInChildren<TextMeshProUGUI>();
        canvasGroup = GetComponent<CanvasGroupPlus>();
    }

    public void SetAction(PawnAction action)
    {
        if (action == null)
        {
            canvasGroup.Visible = false;
            return;
        }
        else
        {
            canvasGroup.Visible = true;
        }

        //TODO
        BasicMoveAction moveAction = action as BasicMoveAction;
        if (moveAction != null)
        {
            if (moveAction.direction == Vector3Int.up)
            {
                tmp.text = "Up";
            }
            else if (moveAction.direction == Vector3Int.down)
            {
                tmp.text = "Down";
            }
            else if (moveAction.direction == Vector3Int.left)
            {
                tmp.text = "Left";
            }
            else if (moveAction.direction == Vector3Int.right)
            {
                tmp.text = "Right";
            }
        }
    }
}
