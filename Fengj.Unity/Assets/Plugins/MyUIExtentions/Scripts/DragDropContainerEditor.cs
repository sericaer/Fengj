#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DragDropContainer))]
public class DragDropContainerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var container = target as DragDropContainer;

        EditorGUI.BeginChangeCheck();

        var isHaveItem = EditorGUILayout.Toggle("isHaveItem", container.isHaveItem);

        if(EditorGUI.EndChangeCheck())
        {
            container.isHaveItem = isHaveItem;
            
            EditorUtility.SetDirty(container);
        }
    }
}
#endif