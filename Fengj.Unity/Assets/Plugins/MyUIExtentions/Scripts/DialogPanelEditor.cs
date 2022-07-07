#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DialogPanel))]
public class DialogPanelEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var dialog = target as DialogPanel;

        EditorGUI.BeginChangeCheck();

        var isMode = EditorGUILayout.Toggle("isMode", dialog.isMode);

        if(EditorGUI.EndChangeCheck())
        {
            dialog.isMode = isMode;
            EditorUtility.SetDirty(dialog);
        }
    }
}
#endif