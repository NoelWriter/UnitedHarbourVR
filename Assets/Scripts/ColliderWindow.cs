using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ColliderWindow : EditorWindow
{
    private string tagStr = "";
    private string state;

    [MenuItem("Window/Edit Colliders")]
    public static void ShowEditorWindow()
    {
        var window = GetWindow<ColliderWindow>();
        window.Show();
    }

    private void OnGUI()
    {
        //Instantiate style for the buttons on the GUI
        GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
        GUILayout.Space(20);

        //Dropdown with available tags. 
        //Tags are passed through the ColliderOptions constructor
        tagStr = EditorGUILayout.TagField("Select tag:", tagStr);


        GUILayout.Space(20);

        //Start a horizontal group with two buttons
        //These buttons both start a method from the class ColliderOptions
        GUILayout.BeginHorizontal();
        if (tagStr != "")
        {
            //Instantiate new collideroptions with the selected tag as parameter
            var collider = new ColliderOptions(tagStr);


            if (GUILayout.Button("Generate " + tagStr + " colliders", buttonStyle))
            {
                collider.Generate();
                state = collider.getState();
            }

            //Make text red on removal button
            buttonStyle.normal.textColor = Color.red;
            if (GUILayout.Button("Remove " + tagStr + " colliders", buttonStyle))
            {
                collider.Remove();
                state = collider.getState();
            }


        }
        GUILayout.EndHorizontal();

        GUILayout.Space(20);

        GUI.Label(new Rect(100, 100, 1000, 20), state);
    }
}