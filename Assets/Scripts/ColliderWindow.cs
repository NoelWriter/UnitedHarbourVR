using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ColliderWindow : EditorWindow
{
    [MenuItem("Window/Edit Colliders")]
    public static void ShowEditorWindow()
    {
        var window = GetWindow<ColliderWindow>();
        window.Show();
    }

    private void OnGUI()
    {
        var collider = new ColliderOptions();
        if (GUILayout.Button("Generate colliders"))
        {
            collider.Generate();
        }

    }
}