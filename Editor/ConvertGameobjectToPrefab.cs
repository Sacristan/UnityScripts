using UnityEngine;
using UnityEditor;

public class ConvertGameObjectPrefabWindow : EditorWindow
{
    private Object prefab;
    private bool cleanUp = true;
    private string namingPattern;
    public GameObject[] gameobjects;
    SerializedObject so;
    private SerializedProperty prop;

    [MenuItem("Window/ConvertGameObjectToPrefab")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        ConvertGameObjectPrefabWindow window = (ConvertGameObjectPrefabWindow)EditorWindow.GetWindow(typeof(ConvertGameObjectPrefabWindow));
        window.Show();
    }
    private void OnEnable()
    {
        so = new SerializedObject(this);
        prop = so.FindProperty("gameobjects");
    }
    private void OnGUI()
    {

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Prefab");
        prefab = EditorGUILayout.ObjectField(prefab, typeof(GameObject), false);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.LabelField("Replacable Scene Objects:");

        EditorGUILayout.PropertyField(prop, true);
        so.ApplyModifiedProperties();

        EditorGUILayout.LabelField("OPTIONAL:");
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Naming pattern: ");
        namingPattern = EditorGUILayout.TextField(namingPattern);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Cleanup replacables: ");
        cleanUp = EditorGUILayout.Toggle(cleanUp);
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Convert!"))
        {
            string pattern = string.IsNullOrEmpty(namingPattern) ? prefab.name : namingPattern;

            for (int i = 0; i < gameobjects.Length; i++)
            {
                GameObject go = gameobjects[i];
                string name = namingPattern + i;

                Debug.LogFormat("Migrating {0} -> {1}...", go.name, name);

                GameObject prefabInstance = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
                prefabInstance.name = name;
                prefabInstance.transform.parent = go.transform.parent;

                prefabInstance.transform.localPosition = go.transform.localPosition;
                prefabInstance.transform.localRotation = go.transform.localRotation;
                prefabInstance.transform.localScale = go.transform.localScale;

                if (cleanUp) DestroyImmediate(go);
            }
        }
    }
}