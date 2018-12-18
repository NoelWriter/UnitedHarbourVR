using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MaterialWindow : EditorWindow
{
    private string tagStr = "";
    private Material selectedMaterial;

    [MenuItem("Window/Edit Materials")]
    public static void ShowEditorWindow()
    {
        var window = GetWindow<MaterialWindow>();
        window.Show();
    }

    private void OnGUI()
    {
        GUILayout.Space(20);
        tagStr = EditorGUILayout.TagField("Select tag:", tagStr);


        if (tagStr != "")
        {
            GUILayout.Space(20);
            selectedMaterial = EditorGUILayout.ObjectField("Select material:", selectedMaterial, typeof(Material), false) as Material;
        }

        var material = new MaterialOptions(tagStr);

        if (selectedMaterial != null)
        {
            GUILayout.Space(20);
            if (GUILayout.Button("Apply Material"))
            {
                material.ApplyMaterial(selectedMaterial);
            }
        }
    }

}
