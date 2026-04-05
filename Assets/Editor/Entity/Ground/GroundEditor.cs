using EditorExtend;
using UnityEditor;

[CustomEditor(typeof(Ground))]
public class GroundEditor : AutoEditor
{
    [AutoProperty]
    public SerializedProperty isObstacle;

    protected override void MyOnInspectorGUI()
    {
        isObstacle.BoolField("障碍物");
    }
}