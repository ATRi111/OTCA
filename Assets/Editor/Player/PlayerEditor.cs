using EditorExtend;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Player))]
public class PlayerEditor : AutoEditor
{
    [AutoProperty]
    public SerializedProperty printingSupply;

    protected override void MyOnInspectorGUI()
    {
        printingSupply.IntField("印料");
    }
}