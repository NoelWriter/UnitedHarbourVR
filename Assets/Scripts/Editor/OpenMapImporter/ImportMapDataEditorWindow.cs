using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class ImportMapDataEditorWindow : EditorWindow
{
    private Material _terrainMaterial;
    private Material _roadMaterial;
    private Material _buildingMaterial;
    private string _mapFilePath = "None (Choose File)";
    private string _progressText;
    private float _progress;
    private bool _disableUI;
    private bool _validFile;
    private bool _importing;

    [MenuItem("Window/Import OpenMap Data")]
    public static void ShowEditorWindow()
    {
        var window = GetWindow<ImportMapDataEditorWindow>();
        window.titleContent = new GUIContent("Import Map");
        window.Show();
    }

    public void ResetProgress()
    {
        _progress = 0f;
        _progressText = "";
    }

    public void UpdateProgress(float progress, string progressText)
    {
        _progress = progress;
        _progressText = progressText;
        Repaint();
    }

    private void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();

        EditorGUI.BeginDisabledGroup(true);
        EditorGUILayout.TextField(_mapFilePath);
        EditorGUI.EndDisabledGroup();
        if (GUILayout.Button("..."))
        {
            var filePath = EditorUtility.OpenFilePanel("Select OpenMap File", Application.dataPath, "txt");
            if (filePath.Length > 0)
            {
                _mapFilePath = filePath;
            }

            _validFile = _mapFilePath.Length > 0;

        }
        



        EditorGUILayout.EndHorizontal();

        _terrainMaterial = EditorGUILayout.ObjectField("Terrain Material", _terrainMaterial, typeof(Material), false) as Material;
        _roadMaterial = EditorGUILayout.ObjectField("Road Material", _roadMaterial, typeof(Material), false) as Material;
        _buildingMaterial = EditorGUILayout.ObjectField("Building Material", _buildingMaterial, typeof(Material), false) as Material;

//        EditorGUI.BeginDisabledGroup(!_validFile || _disableUI);
        EditorGUI.BeginDisabledGroup(!_validFile || _importing);
        if (GUILayout.Button("Import Map File"))
        {
            _importing = true;

            var mapWrapper = new ImportMapWrapper(this, 
                                                  _mapFilePath,
                                                  _terrainMaterial,
                                                  _roadMaterial, 
                                                  _buildingMaterial);

            mapWrapper.Import();

            _importing = false;
        }
        EditorGUI.EndDisabledGroup();

        if (_importing)
        {
            var rect = EditorGUILayout.BeginHorizontal();
            rect.height = 24;

            EditorGUI.ProgressBar(rect, _progress, _progressText);

            EditorGUILayout.EndHorizontal();
        }

        if (_disableUI)
        {
            EditorGUILayout.HelpBox("The current scene has not been saved yet!", MessageType.Warning, true);
        }

    }

 //   private void Update()
 //   {
 //       _disableUI = EditorSceneManager.GetActiveScene().isDirty;
 //   }

}
