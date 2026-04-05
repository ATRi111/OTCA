using EditorExtend;
using UnityEditor;

[CustomEditor(typeof(Player))]
public class PlayerEditor : PawnEditor
{
    [AutoProperty]
    public SerializedProperty printingSupply;

    protected override void MyOnInspectorGUI()
    {
        printingSupply.IntField("印料");
    }
}