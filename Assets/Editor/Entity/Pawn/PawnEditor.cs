using UnityEditor;

[CustomEditor(typeof(Pawn))]
public class PawnEditor : EntityEditor
{
    //[AutoProperty]
    //public SerializedProperty data;

    protected override void MyOnInspectorGUI()
    {
        base.MyOnInspectorGUI();
    }
}